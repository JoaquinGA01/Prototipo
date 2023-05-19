using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class MultiplesModelos : MonoBehaviour{
    [SerializeField] private ARTrackedImageManager aRTrackedImageManager;
    [SerializeField] private GameObject[] arModelsToPlace;

    private Dictionary<string, GameObject> arModels = new Dictionary<string, GameObject>();
    private Dictionary<string, bool> modelState = new Dictionary<string,bool>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (var arModel in arModelsToPlace)
        {
            GameObject newARModel = Instantiate(arModel, Vector3.zero, Quaternion.identity);
            newARModel.name = arModel.name;
            arModels.Add(newARModel.name,newARModel);
            newARModel.SetActive(false);
            modelState.Add(newARModel.name,false);
        }
    }

    private void OnEnable(){
        aRTrackedImageManager.trackedImagesChanged += ImageFound;
    }

    private void OnDisable(){
        aRTrackedImageManager.trackedImagesChanged -= ImageFound;
    }

    private void ImageFound(ARTrackedImagesChangedEventArgs eventData){
        foreach (var trackedImage in eventData.added)
        {
            ShowARModel(trackedImage);
        }
        foreach (var trackedImage in eventData.updated)
        {
            if (trackedImage.trackingState == TrackingState.Tracking){
                ShowARModel(trackedImage);
            }else if(trackedImage.trackingState == TrackingState.Limited){
                HideARmodel(trackedImage);
            }
        }
    }

    private void ShowARModel(ARTrackedImage trackedImage){
        bool isModelActivated = modelState[trackedImage.referenceImage.name];
        if(!isModelActivated){
            GameObject arModel = arModels[trackedImage.referenceImage.name];
            arModel.transform.position = trackedImage.transform.position;
            arModel.SetActive(true);
            modelState[trackedImage.referenceImage.name]=true;
        }else{
            GameObject arModel = arModels[trackedImage.referenceImage.name];
            arModel.transform.position = trackedImage.transform.position;
        }
    }

    private void HideARmodel(ARTrackedImage trackedImage){
        bool isModelActivated = modelState[trackedImage.referenceImage.name];
        if(isModelActivated){
            GameObject arModel = arModels[trackedImage.referenceImage.name];
            arModel.SetActive(false);
            modelState[trackedImage.referenceImage.name]=false;
        }        
    }
}
