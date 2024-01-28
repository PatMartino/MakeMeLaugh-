using System;
using System.Collections;
using System.Threading;
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
        private int _score=0;

        #endregion

        #region OnEnable

        private void OnEnable()
        {
            CoreGameSignals.Instance.OnGetScore += OnGetScore;
            CoreGameSignals.Instance.OnIncreaseScore += OnIncreaseScore;
        }

        private void Start()
        {
            StartCoroutine(CreatingTearDrops());
            StartCoroutine(CreatingBasicToys());
            StartCoroutine(CreatingCar());
            StartCoroutine(CreatingTrain());
            StartCoroutine(CreatingRings());
            StartCoroutine(CreatingHealth());
        }

        #endregion

        #region Private Functions

        private IEnumerator CreatingTearDrops()
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
                    if (CoreGameSignals.Instance.OnGetHealth() == 0)
                    {
                        break;
                    }
                    yield return new WaitForSeconds(randomTimeTear);
                    if (CoreGameSignals.Instance.OnGetHealth() == 0)
                    {
                        break;
                    }
                    //if (!EditorApplication.isPlaying) { 
                    //   break;
                    //}

                    if (Time.timeScale != 0)
                    {
                        Instantiate(Resources.Load<GameObject>("TearDrop/TearDrop"),randomPlace,Quaternion.identity,holder); 
                    }
                    
                
            }
        }
        private IEnumerator CreatingRings()
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
                    if (CoreGameSignals.Instance.OnGetHealth() == 0)
                    {
                        break;
                    }
                    yield return new WaitForSeconds(randomTimeRings);
                    if (CoreGameSignals.Instance.OnGetHealth() == 0)
                    {
                        break;
                    }
                    //if (!EditorApplication.isPlaying) { 
                    //   break;
                    //}
                    if (CoreGameSignals.Instance.OnGetHealth() == 0)
                    {
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
                    yield return new WaitForSeconds(4);
                }
                Debug.Log("Level Manager: " + _ringCounter);
                Debug.Log("Ring Counter: " + CoreGameSignals.Instance.OnGetRingCount());
                //if (!EditorApplication.isPlaying) { 
                //   break;
                //}
                if (CoreGameSignals.Instance.OnGetHealth() == 0)
                {
                    break;
                }
            }
        }

        private IEnumerator CreatingBasicToys()
        {
            float randomXtoy;
            float randomYtoy;
            float randomTimeToy;
            while (true)
            {
                randomXtoy = Random.Range(-7f, 7f);
                randomYtoy = Random.Range(-4f, 0f);
                randomTimeToy = Random.Range(4f, 9f);
                var randomPlace = new Vector3(randomXtoy, randomYtoy, 0);
                if (CoreGameSignals.Instance.OnGetHealth() == 0)
                {
                    break;
                }
                yield return new WaitForSeconds(randomTimeToy); 
                //if (!EditorApplication.isPlaying) { 
                //   break;
                //}
                if (CoreGameSignals.Instance.OnGetHealth() == 0)
                {
                    break;
                }
                Instantiate(Resources.Load<GameObject>("Toys/BasicToy/BasicToy"),randomPlace,Quaternion.Euler(0,0,-45),holder);
                
            }
        }
        
        private IEnumerator CreatingHealth()
        {
            float randomXtoy;
            float randomYtoy;
            float randomTimeToy;
            while (true)
            {
                randomXtoy = Random.Range(-7f, 7f);
                randomYtoy = Random.Range(-4f, 0f);
                randomTimeToy = Random.Range(25f, 40f);
                var randomPlace = new Vector3(randomXtoy, randomYtoy, 0);
                if (CoreGameSignals.Instance.OnGetHealth() == 0)
                {
                    break;
                }
                yield return new WaitForSeconds(randomTimeToy);
                //if (!EditorApplication.isPlaying) { 
                //   break;
                //}
                if (CoreGameSignals.Instance.OnGetHealth() == 0)
                {
                    break;
                }
                Instantiate(Resources.Load<GameObject>("Health/Health"),randomPlace,Quaternion.identity,holder);
                
            }
        }

        private IEnumerator CreatingCar()
        {
            float randomYCar;
            float randomTimeCar;
            while (true)
            {
                randomYCar = Random.Range(-4f, 0f);
                randomTimeCar = Random.Range(6f, 15f);
                var randomPlace = new Vector3(-10f, randomYCar, 0f);
                if (CoreGameSignals.Instance.OnGetHealth() == 0)
                {
                    break;
                }
                yield return new WaitForSeconds(randomTimeCar);  
                //if (!EditorApplication.isPlaying) { 
                //   break;
                //}
                if (CoreGameSignals.Instance.OnGetHealth() == 0)
                {
                    break;
                }
                Instantiate(Resources.Load<GameObject>("Vecihles/Car"),randomPlace,Quaternion.identity,holder);
                
            }
        }
        
        private IEnumerator CreatingTrain()
        {
            float randomYTrain;
            float randomTimeTrain;
            while (true)
            {
                randomYTrain = Random.Range(-4f, 0f);
                randomTimeTrain = Random.Range(6f, 15f);
                var randomPlace = new Vector3(-10, randomYTrain, 0);
                if (CoreGameSignals.Instance.OnGetHealth() == 0)
                {
                    break;
                }
                yield return new WaitForSeconds(randomTimeTrain); 
                //if (!EditorApplication.isPlaying) { 
                //   break;
                //}
                if (CoreGameSignals.Instance.OnGetHealth() == 0)
                {
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
                randomMaxTime = 0.8f;
                randomMinTime = 0.1f;
                _randomTime = Random.Range(randomMinTime, randomMaxTime);  
            }
            else if (CoreGameSignals.Instance.OnGetLaughMeterLevels() == LaughMeterLevels.Easy)
            {
                randomMaxTime = 2f;
                randomMinTime = 0.9f;
                _randomTime = Random.Range(randomMinTime, randomMaxTime);  
            }
            else
            {
                _randomTime = 10;
            }
        }

        private int OnGetScore()
        {
            return _score;
        }

        private void OnIncreaseScore(int amount)
        {
            _score += amount;
        }

        public void DestroySelf()
        {
            gameObject.SetActive(false);
        }

        #endregion
        
    }
}
