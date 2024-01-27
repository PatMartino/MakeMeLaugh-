using System;
using System.Threading.Tasks;
using Enums;
using Signals;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        #region Serialize Fields

        [SerializeField] private Transform holder;

        #endregion
        
        #region Private Fields

        private int _ringCounter=0;
        private float _randomTime = 5;

        #endregion

        #region OnEnable

        private void Start()
        {
            CreatingTearDrops();
            CreatingBasicToys();
            CreatingCar();
            CreatingTrain();
            CreatingRings();
        }

        #endregion

        #region Private Functions

        private async void CreatingTearDrops()
        {
            float randomXTear;
            float randomYTear;
            float randomTimeTear;
            while (true)
            {
                randomXTear = Random.Range(-8f, 8f);
                randomYTear = Random.Range(-4f, 0f);
                var randomPlace = new Vector3(randomXTear, randomYTear, 0);
                WaitTearDropByLevelCount();
                randomTimeTear = _randomTime;
                await Task.Delay((int)(randomTimeTear*1000));  
                if (!EditorApplication.isPlaying) { 
                    break;
                }
                Instantiate(Resources.Load<GameObject>("TearDrop/TearDrop"),randomPlace,Quaternion.identity,holder);
                
            }
        }
        private async void CreatingRings()
        {
            float randomXRings;
            float randomYRings;
            float randomTimeRings;
            while (true)
            {
                if (_ringCounter == CoreGameSignals.Instance.OnGetRingCount())
                { 
                    randomXRings = Random.Range(-8f, 8f);
                    randomYRings = Random.Range(-4f, 0f);
                    var randomPlace = new Vector3(randomXRings, randomYRings, 0);
                    randomTimeRings = Random.Range(8, 15);
                    Debug.Log(randomTimeRings);
                    await Task.Delay((int)(randomTimeRings*1000));
                    if (!EditorApplication.isPlaying) { 
                        break;
                    }
                    if (_ringCounter<5)
                    {
                        if (_ringCounter == CoreGameSignals.Instance.OnGetRingCount())
                        {
                            _ringCounter++;
                            Instantiate(Resources.Load<GameObject>($"Rings/Ring{_ringCounter}"), randomPlace, Quaternion.identity, holder);
                        }
                    }
                    else
                    {
                        _ringCounter = 0;
                    }

                    if (_ringCounter==5)
                    {
                        _ringCounter = 0;
                    }
                    
                
                }
                else
                {
                    await Task.Delay(4000);
                }
                Debug.Log("Level Manager: " + _ringCounter);
                Debug.Log("Ring Counter: " + CoreGameSignals.Instance.OnGetRingCount());
                if (!EditorApplication.isPlaying) { 
                    break;
                }
            }
        }

        private async void CreatingBasicToys()
        {
            float randomXtoy;
            float randomYtoy;
            while (true)
            {
                randomXtoy = Random.Range(-7f, 7f);
                randomYtoy = Random.Range(-4f, 0f);
                var randomPlace = new Vector3(randomXtoy, randomYtoy, 0);
                await Task.Delay(7000); 
                if (!EditorApplication.isPlaying) { 
                    break;
                }
                Instantiate(Resources.Load<GameObject>("Toys/BasicToy/BasicToy"),randomPlace,Quaternion.Euler(0,0,-45),holder);
                
            }
        }

        private async void CreatingCar()
        {
            float randomYCar;
            float randomTimeCar;
            while (true)
            {
                randomYCar = Random.Range(-4f, 0f);
                randomTimeCar = Random.Range(6f, 15f);
                var randomPlace = new Vector3(-10f, randomYCar, 0f);
                await Task.Delay((int)randomTimeCar*1000);  
                if (!EditorApplication.isPlaying) { 
                    break;
                }
                Instantiate(Resources.Load<GameObject>("Vecihles/Car"),randomPlace,Quaternion.identity,holder);
                
            }
        }
        
        private async void CreatingTrain()
        {
            float randomYTrain;
            float randomTimeTrain;
            while (true)
            {
                randomYTrain = Random.Range(-4f, 0f);
                randomTimeTrain = Random.Range(6f, 15f);
                var randomPlace = new Vector3(-10, randomYTrain, 0);
                await Task.Delay((int)randomTimeTrain*1000); 
                if (!EditorApplication.isPlaying) { 
                    break;
                }
                Instantiate(Resources.Load<GameObject>("Vecihles/Train"),randomPlace,Quaternion.identity,holder);
                
            }
        }

        private void WaitTearDropByLevelCount()
        {
            float randomMaxTime;
            float randomMinTime;
            if (CoreGameSignals.Instance.OnGetLaughMeterLevels() == LaughMeterLevels.Medium)
            {
                randomMaxTime = 1.5f;
                randomMinTime = 0.6f;
                _randomTime = Random.Range(randomMinTime, randomMaxTime);
            }
            else if (CoreGameSignals.Instance.OnGetLaughMeterLevels() == LaughMeterLevels.Hard)
            {
                randomMaxTime = 0.9f;
                randomMinTime = 0.2f;
                _randomTime = Random.Range(randomMinTime, randomMaxTime);  
            }
            else if (CoreGameSignals.Instance.OnGetLaughMeterLevels() == LaughMeterLevels.Impossible)
            {
                randomMaxTime = 0.7f;
                randomMinTime = 0f;
                _randomTime = Random.Range(randomMinTime, randomMaxTime);  
            }
            else
            {
                _randomTime = 10;
            }
        }

        #endregion
        
    }
}
