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
        private Vector3 _placeTear = new Vector3(2f,3f,1);
        private Vector3 _placeBasicToy = new Vector3(2f,3f,1);
        private Vector3 _placeCar = new Vector3(2f,3f,1);
        private Vector3 _placeTrain = new Vector3(2f,3f,1);

        #endregion
        
        #region Private Fields

        //private float _randomX;
        //private float _randomY;
        //private float _randomMaxTime;
        //private float _randomMinTime;
        private float _randomTime = 5;

        #endregion

        #region OnEnable

        private void Start()
        {
            CreatingTearDrops();
            CreatingBasicToys();
            CreatingCar();
            CreatingTrain();
        }

        #endregion

        #region Private Functions

        private async void CreatingTearDrops()
        {
            float randomXTear;
            float randomYTear;
            while (true)
            {
                randomXTear = Random.Range(-8f, 8f);
                randomYTear = Random.Range(-4f, 0f);
                var randomPlace = new Vector3(randomXTear, randomYTear, 0);
                WaitTearDropByLevelCount();
                _placeTear = randomPlace;
                await Task.Delay((int)_randomTime*1000);  
                Instantiate(Resources.Load<GameObject>("TearDrop/TearDrop"),randomPlace,Quaternion.identity,holder);
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
                _placeBasicToy = randomPlace;
                await Task.Delay(7000);  
                Instantiate(Resources.Load<GameObject>("Toys/BasicToy/BasicToy"),randomPlace,Quaternion.identity,holder);
                if (!EditorApplication.isPlaying) { 
                    break;
                }
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
                _placeCar = randomPlace;
                await Task.Delay((int)randomTimeCar*1000);  
                Instantiate(Resources.Load<GameObject>("Vecihles/Car"),randomPlace,Quaternion.identity,holder);
                if (!EditorApplication.isPlaying) { 
                    break;
                }
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
                _placeTrain = randomPlace;
                await Task.Delay((int)randomTimeTrain*1000);  
                Instantiate(Resources.Load<GameObject>("Vecihles/Train"),randomPlace,Quaternion.identity,holder);
                if (!EditorApplication.isPlaying) { 
                    break;
                }
            }
        }

        private void WaitTearDropByLevelCount()
        {
            float randomMaxTime;
            float randomMinTime;
            if (CoreGameSignals.Instance.OnGetLaughMeterLevels() == LaughMeterLevels.Medium)
            {
                randomMaxTime = 4f;
                randomMinTime = 1f;
                _randomTime = Random.Range(randomMinTime, randomMaxTime);
            }
            else if (CoreGameSignals.Instance.OnGetLaughMeterLevels() == LaughMeterLevels.Hard)
            {
                randomMaxTime = 3f;
                randomMinTime = 0.5f;
                _randomTime = Random.Range(randomMinTime, randomMaxTime);  
            }
            else if (CoreGameSignals.Instance.OnGetLaughMeterLevels() == LaughMeterLevels.Impossible)
            {
                randomMaxTime = 1.5f;
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
