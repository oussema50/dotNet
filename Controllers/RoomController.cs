using projetDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projetDotNet.Controllers
{
    public class RoomController : Controller
    {
        TekupContext myDB = new TekupContext();

        public ActionResult Index()
        {
            List<Room> roomList = new List<Room>();
            roomList = (from room in myDB.rooms select room).ToList();
            return View(roomList);
        }

        public ActionResult GetRoom(int id)
        {
            Room room = new Room();
            room = (from obj in myDB.rooms
                      where obj.roomID == id
                      select obj).FirstOrDefault();
            return View("RoomDetails",room);
        }

        public ActionResult InsertRoom()
        {
            Room r = new Room();
            r.roomName = "100";
            r.roomSize = 40;
            r.isAvailable = true;
            myDB.rooms.Add(r);
            myDB.SaveChanges();
            return View("index");
        }

        public ActionResult UpdateRoom(int id )
        {
            Room r = new Room();
            r = (from obj in myDB.rooms
                    where obj.roomID == id
                    select obj).FirstOrDefault();
            r.roomName = "200";
            r.roomSize = 40;
            r.isAvailable = false;
            myDB.rooms.Add(r);
            myDB.SaveChanges();
            return View("index");
        }
        public ActionResult DeleteRoom(int id)
        {
            Room room = new Room();
            room = (from obj in myDB.rooms
                    where obj.roomID == id
                    select obj).FirstOrDefault();
            myDB.rooms.Remove(room);
            myDB.SaveChanges();

            return View("");
        }
    }
}