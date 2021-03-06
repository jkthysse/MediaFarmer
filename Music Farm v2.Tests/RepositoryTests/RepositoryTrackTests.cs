﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaFarmer.Context.Repositories;
using MediaFarmer.ViewModels;
using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace MediaFarmer.Tests.RepositoryTests
{
    [TestClass]
    public class RepositoryTrackTests
    {
        Moq.Mock<MusicFarmerEntities> context;
        RepositoryTrack repos;

        [TestInitialize]
        public void InitializeTests()
        {
            context = new Mock.Database.MockData.MockTrackTests().MockContext;
            repos = new RepositoryTrack(new Uow(context.Object));
        }
        [TestMethod]
        public void ShouldGetAllFilteredTracksByName()
        {
           List<TrackViewModel> _Track= repos.SearchTrackByName("Track1");
            var _TrackId = _Track.Find(i => i.TrackName == "Track1").TrackId;
            Assert.AreEqual(1, _TrackId);
        }

        [TestMethod]
        public void ShouldGetAllFilteredTracks()
        {
            List<TrackViewModel> _Track = repos.SearchTrackByName("");
            
            Assert.IsTrue(_Track.Count==4);
        }
        [TestMethod]
        public void ShouldGetAllFilteredTracksByAlbumName()
        {
            List<TrackViewModel> _Track = repos.SearchTrackByAlbumName("TestAlbum");
            Assert.IsTrue(_Track.Count == 3);
        }
        [TestMethod]
        public void ShouldGetAllFilteredTracksByArtistName()
        {
            List<TrackViewModel> _Track = repos.SearchTrackByArtistName("Artist 1");
            Assert.IsTrue(_Track.Count == 2);
        }

        [TestMethod]
        public void ShouldUpdateTrackDetails()
        {
            TrackViewModel _Track = new TrackViewModel
            {
                TrackId = 1,
                TrackName = "1",
                AlbumId = 1,
                ArtistId = 1,
                TrackURL = "C:\\Media\\Music\\Track1.mp3",
            };
            repos.UpdateTrackInfo(_Track);
            Assert.IsTrue(context.Object.Tracks.Count(i=>i.TrackName=="1") == 1);
        }
    }
}
