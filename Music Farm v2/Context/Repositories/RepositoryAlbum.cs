﻿using MediaFarmer.Context.Extensions;
using MediaFarmer.ViewModels;
using UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MusicFarmer.Data;

namespace MediaFarmer.Context.Repositories
{
    public class RepositoryAlbum
    {
        private static IUow _uow;
        private static IRepository<Album> repo;
        public RepositoryAlbum(IUow uow)
        {
            _uow = uow;
            repo = _uow.GetRepo<Album>();
        }

        public List<AlbumViewModel> GetFilteredAlbums(string filter)
        {
            return repo.GetByQuery(i => i.AlbumName.Contains(filter)).Select(i => i.ToModel()).ToList();
        }

        public List<AlbumViewModel> GetAllAlbums()
        {
            return repo.GetByQuery().Select(i => i.ToModel()).ToList();
        }

        public List<AlbumViewModel> GetAlbumId(string _AlbumName)
        {
            return repo.GetByQuery(i=>i.AlbumName== _AlbumName).Select(i => i.ToModel()).ToList();
        }

        public void AddAlbum(AlbumViewModel _Album)
        {
            repo.Add(_Album.ToData());
            repo.SaveChanges();
        }
    }
}