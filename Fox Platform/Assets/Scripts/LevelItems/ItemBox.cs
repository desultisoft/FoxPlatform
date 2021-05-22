using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Items
{
    public class ItemBox : MonoBehaviour
    {
        private SpriteRenderer rend;
        private Collider2D collider;
        private Item randomItem;
        private Item _itemInstance;
        
        [SerializeField]private float inactiveDuraction;
        [SerializeField]private List<Item> PossibleItems;
        
        public void Awake()
        {
            collider = GetComponent<Collider2D>();
            rend = GetComponent<SpriteRenderer>();
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            //Pickup the item.
            Player player = other.GetComponent<Player>();
            if (player!=null && !player.itemManager.isHoldingItem)
            {
                if (PossibleItems.Any())
                {
                    randomItem = PossibleItems[Random.Range(0, PossibleItems.Count)];
                }
                randomItem.gameObject.SetActive(false);
                
                _itemInstance = Instantiate(randomItem);
                _itemInstance.transform.SetParent(transform);
                _itemInstance.transform.localPosition = Vector3.zero;
                
                randomItem.gameObject.SetActive(true);
                
                player.itemManager.Equip(_itemInstance);
                StartCoroutine(Deactivate(inactiveDuraction));
            }
        }
        private IEnumerator Deactivate(float duration)
        {
            //Consume the gem
            collider.enabled = false;
            rend.enabled = false;
            
            yield return new WaitForSeconds(duration);
            
            //return to normal
            collider.enabled = true;
            rend.enabled = true;
        }
    }
}