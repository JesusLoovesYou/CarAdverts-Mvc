﻿using Bytes2you.Validation;
using CarAdverts.Data.Providers.EfProvider;
using CarAdverts.Models;
using CarAdverts.Services.Contracts;

namespace CarAdverts.Services
{
    public class FileService : IFileService
    {
        private IEfCarAdvertsDataProvider efProvider;

        public FileService(IEfCarAdvertsDataProvider efProvider)
        {
            Guard.WhenArgument(efProvider, nameof(efProvider)).IsNull().Throw();

            this.efProvider = efProvider;
        }

        public File GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var file = this.efProvider.Files.GetById(id);
            return file;
        }
    }
}
