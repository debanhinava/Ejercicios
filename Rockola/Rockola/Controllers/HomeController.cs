﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

namespace Rockola.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SearchList(string Keywork)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {

                //ApiKey = "AIzaSyDOWDXSYml18hvagwa91sPt0nHhFkSpWnA",

                //ApiKey = "AIzaSyCEvhnL2M-HB5bv_5w1boEYgSEKd_LsQww",
                //Ana
                ApiKey= "AIzaSyCR3cGBWQwPAAL1d5F5wOd-3GnBn6quCO0",
                ApplicationName = this.GetType().ToString()
            });
            var SearchListRequest = youtubeService.Search.List("snippet");
            SearchListRequest.Q = Keywork;
            SearchListRequest.MaxResults = 10;

            var searchListResponse = SearchListRequest.Execute();
 

            return PartialView("Search",searchListResponse.Items);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        public void Declare()
        {
            List<string> PlayListIds = new List<string>();
            if(Session["Playlist"]==null)
            {
                Session["Playlist"] = PlayListIds;
            }
        }

        [HttpGet]
        public ActionResult AddToPlaylist(string IdVideo)
        {
            Declare();
            
            List<string>
                ListVideosId = (List<string>)Session["Playlist"];
            ListVideosId.Add(IdVideo);
            return PartialView("Playlist", ListVideosId);
            
        }
    }
}