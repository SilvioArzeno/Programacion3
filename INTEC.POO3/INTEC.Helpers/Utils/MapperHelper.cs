﻿using System;
using AutoMapper;
using INTEC.Data.Entities;
using INTEC.Models.ViewModels;

namespace INTEC.Helpers.Utils
{
    public class MapperHelper
    {
        static MapperHelper _instance;

        MapperHelper()
        {
            Mapper.Initialize(conf =>
            {
                conf.CreateMap<User, UserViewModel>().ForMember(i=> i.maria, if. );
                conf.CreateMap<UserProfile, UserProfileViewModel>();


            });
        }

        public static MapperHelper Instance
        {
            get{
                if(_instance == null)
                {
                    _instance = new MapperHelper();
                }

                return _instance;
            }
        }

        public To Map<From, To>(From obj)
        {
            return Mapper.Map<To>(obj);
        }

        public To Map<From, To>(From from, To to)
        {
            return Mapper.Map(from, to);
        }
    }
}
