using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using ARLocation.UI;
using System;

namespace ARLocation
{

    //public class Objeto
    //{
    //    public GameObject animal { get; set; }
    //    public String nombre { get; set; }
    //    public String texto { get; set; }
    //    public Location location { get; set; }

    //    public Objeto(GameObject animal, String nombre, String texto, Location location) {
    //        this.animal = animal;
    //        this.nombre = nombre;
    //        this.texto = texto;
    //        this.location = location;
    //    }

    //}

    public class TestObjects : MonoBehaviour
    {

        public GameObject[] objetos = new GameObject[5];

        public Hotspot.HotspotSettingsData HotspotSettings = new Hotspot.HotspotSettingsData();

        private Camera arCamera;

        private readonly Hotspot.StateData state = new Hotspot.StateData();

        public Hotspot.OnHotspotLeaveUnityEvent OnHotspotLeave = new Hotspot.OnHotspotLeaveUnityEvent();

        //Damos las localizaciones a mano

         

        static Location loc1 = new Location()
        {
            Latitude = 43.33068486416555,
            Longitude = -8.372379507517993,
            Altitude = 0,
            AltitudeMode = AltitudeMode.GroundRelative
        };

        static Location loc2 = new Location()
        {
            Latitude = 43.33115765175588,
            Longitude = -8.371467373450326,
            Altitude = 0,
            AltitudeMode = AltitudeMode.GroundRelative
        };

        static Location loc3 = new Location()
        {
            Latitude = 43.33144399498649,
            Longitude = -8.371472911065739,
            Altitude = 0,
            AltitudeMode = AltitudeMode.GroundRelative
        };

        static Location loc4 = new Location()
        {
            Latitude = 43.33122415243056,
            Longitude = -8.372257811119184,
            Altitude = 0,
            AltitudeMode = AltitudeMode.GroundRelative
        };

        static Location loc5 = new Location()
        {
            Latitude = 43.33044496458753,
            Longitude = -8.372058970544197,
            Altitude = 0,
            AltitudeMode = AltitudeMode.GroundRelative
        };

        Location[] locs = { loc1, loc2, loc3, loc4, loc5 };



        //La opciones también
        PlaceAtLocation.PlaceAtOptions opts = new PlaceAtLocation.PlaceAtOptions()
        {
            HideObjectUntilItIsPlaced = true,
            MaxNumberOfLocationUpdates = 2,
            MovementSmoothing = 0.1f,
            UseMovingAverage = false
        };


        public void Start()
        {

            //Instanciamos cada objeto en su ubicación
            for (var i = 0; i <= objetos.Length; i++)
            {
                PlaceAtLocation.CreatePlacedInstance(objetos[i], locs[i], opts);
                Hotspot.CreateHotspotGameObject(locs[i], HotspotSettings, "GPS Hotspot");
            }

        }


        public void Update()
        {
            var distance = Vector3.Distance(arCamera.transform.position, state.Instance.transform.position);
            if (distance >= HotspotSettings.ActivationRadius)
            {
                OnHotspotLeave?.Invoke(state.Instance);
                state.EmittedLeaveHotspotEvent = true;
                VikingCrew.Tools.UI.SpeechBubbleManager.Instance.AddSpeechBubble(transform, "Hello world!");
            }
        }

    }



}

