﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MyShop.Core
{

    public class DealerDataService
    {
        private static DealerRepoisitory dealerRepository = new DealerRepoisitory();
        public DealerDataService() { }

        public List<Dealer> GetAllDealers()
        {
            return dealerRepository.GetAllDealers();
        }

        public Dealer GetDealersById(int dealerId)
        {
            return dealerRepository.GetDealerById(dealerId);
        }
    }

	public class HotDogDataService
	{
		//private static HotDogWebRepository hotDogRepository = new HotDogWebRepository();
		private static HotDogRepository hotDogRepository = new HotDogRepository();

		public HotDogDataService ()
		{
		}

		public List<HotDog> GetAllHotDogs()
		{
			return hotDogRepository.GetAllHotDogs();
		}

		public List<HotDogGroup> GetGroupedHotDogs()
		{
			return hotDogRepository.GetGroupedHotDogs ();
		}

		public List<HotDog> GetHotDogsForGroup(int hotDogGroupId)
		{
			return hotDogRepository.GetHotDogsForGroup (hotDogGroupId);
		}

		public List<HotDog> GetFavoriteHotDogs()
		{
			return hotDogRepository.GetFavoriteHotDogs ();
		}

		public HotDog GetHotDogById(int hotDogId)
		{
			return hotDogRepository.GetHotDogById (hotDogId);
		}

	}
}

