﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class InventoryItem : MonoBehaviour, IDataPersister
    {
        public string inventoryKey = "";
        public LayerMask layers;
        public bool disableOnEnter = false;

        [HideInInspector]
        new public CircleCollider2D collider;

        public AudioClip clip;
        public DataSettings dataSettings;

        void OnEnable()
        {
            collider = GetComponent<CircleCollider2D>();
            PersistentDataManager.RegisterPersister(this);
        }

        void OnDisable()
        {
            PersistentDataManager.UnregisterPersister(this);
        }

        void Reset()
        {
            layers = LayerMask.NameToLayer("Everything");
            collider = GetComponent<CircleCollider2D>();
            collider.radius = 5;
            collider.isTrigger = true;
            dataSettings = new DataSettings();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (layers.Contains(other.gameObject))
            {
                var ic = other.GetComponent<InventoryController>();
                ic.AddItem(inventoryKey);
                if (disableOnEnter)
                {
                    gameObject.SetActive(false);
                    Save();
                }

                if (clip) AudioSource.PlayClipAtPoint(clip, transform.position);

            }
        }

        public void Save()
        {
            PersistentDataManager.SetDirty(this);
        }

        void OnDrawGizmos()
        {
            Gizmos.DrawIcon(transform.position, "InventoryItem", false);
        }

        public DataSettings GetDataSettings()
        {
            return dataSettings;
        }

        public void SetDataSettings(string dataTag, DataSettings.PersistenceType persistenceType)
        {
            dataSettings.dataTag = dataTag;
            dataSettings.persistenceType = persistenceType;
        }

        public Data SaveData()
        {
            return new Data<bool>(gameObject.activeSelf);
        }

        public void LoadData(Data data)
        {
            Data<bool> inventoryItemData = (Data<bool>)data;
            gameObject.SetActive(inventoryItemData.value);
        }
    }
}
