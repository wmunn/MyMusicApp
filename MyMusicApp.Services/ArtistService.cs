﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyMusicApp.Domain;
using MyMusicApp.DAO;
using MyMusicApp.Models;

namespace MyMusicApp.Services
{
    public class ArtistService
    {
        public List<ArtistModel> getArtists() {
            List<Artist> theList = new List<Artist>(ArtistDao.Instance.select());
            IEnumerable<ArtistModel> selectedModels = theList.Select(x => new ArtistModel {ArtistId=x.ArtistId, Name=x.Name});
            List<ArtistModel> modelList = selectedModels.ToList<ArtistModel>();

            return modelList;
        }
    }
}
