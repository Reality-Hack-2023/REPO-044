/******************************************************************************
 * File: ImageTrackingSampleController.cs
 * Copyright (c) 2022 Qualcomm Technologies, Inc. and/or its subsidiaries. All rights reserved.
 *
 * Confidential and Proprietary - Qualcomm Technologies, Inc.
 *
 ******************************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace Qualcomm.Snapdragon.Spaces.Samples
{
    public class Show3DModel : SampleController
    {
        public ARTrackedImageManager arImageManager;

        public GameObject Q1Model;
        public GameObject Q2Model;
        public GameObject Q3Model;


        public override void OnEnable() {
            base.OnEnable();
            arImageManager = GameObject.FindObjectOfType<ARTrackedImageManager>();
            arImageManager.trackedImagesChanged += OnTrackedImagesChanged;
        }

        public override void OnDisable() {
            base.OnDisable();
            arImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
        }

        private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs args) {
            foreach (var trackedImage in args.added) {
                if (trackedImage.referenceImage.name == "Q1 image"){
                    Q1Model.transform.position = trackedImage.transform.position;
                    Q1Model.SetActive(true);
                    Q2Model.SetActive(false);
                    Q3Model.SetActive(false);}

                    //SceneManager.LoadScene(1);
                
                if (trackedImage.referenceImage.name == "Q2 image"){
                    Q2Model.transform.position = trackedImage.transform.position;
                    Q1Model.SetActive(false);
                    Q2Model.SetActive(true);
                    Q3Model.SetActive(false);}
                
                if (trackedImage.referenceImage.name == "Q3 image"){
                    Q3Model.transform.position = trackedImage.transform.position;
                    Q1Model.SetActive(false);
                    Q2Model.SetActive(false);
                    Q3Model.SetActive(true);}
            }

            // foreach (var trackedImage in args.updated) {
            //     if (trackedImage.referenceImage.name == "Q1 image")
            //         Q1Model.transform.position = trackedImage.transform.position;
                
            //     if (trackedImage.referenceImage.name == "Q2 image")
            //         Q2Model.transform.position = trackedImage.transform.position;
                
            //     if (trackedImage.referenceImage.name == "Q3 image")
            //         Q3Model.transform.position = trackedImage.transform.position;
            // }
        }
    }
}