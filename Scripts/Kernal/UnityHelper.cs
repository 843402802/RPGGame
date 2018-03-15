
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Kernal
{
    /// <summary>
    /// 项目开发中常用算法
    /// </summary>
    public class UnityHelper
    {
        private static float _FloDeltaTime;//累计时间
        private static UnityHelper _Instance;

        private UnityHelper()
        {
        }

        public static UnityHelper GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new UnityHelper();
            }
            return _Instance;
        }

        /// <summary>
        /// 间隔指定时间段，返回布尔值
        /// </summary>
        /// <param name="smallIntervalTime">指定的时间段间隔(0.1-3F之间)</param>
        /// <returns>true：表示指定时间段到了</returns>
        public bool GetSmallTime(float smallIntervalTime)
        {
            _FloDeltaTime += Time.deltaTime;
            if (_FloDeltaTime >= smallIntervalTime)
            {
                _FloDeltaTime = 0F;
                return true;
            }
            return false;
        }

        /// <summary>
        /// （角色）面向指定目标旋转
        /// </summary>
        /// <param name="self">本身</param>
        /// <param name="goal">目标</param>
        /// <param name="floRotatSpeed">旋转速度</param>
        public void FaceToGoal(Transform self, Transform goal, float floRotatSpeed)
        {
            self.rotation =
            Quaternion.Slerp(
                            self.rotation,
                            Quaternion.LookRotation(new Vector3(goal.position.x, 0, goal.position.z) -
                                new Vector3(self.position.x, 0, self.position.z)), floRotatSpeed
                                );
        }

        /// <summary>
        /// 得到指定范围的随机整数
        /// </summary>
        /// <param name="minNum">最小数值</param>
        /// <param name="MaxNum">最大数值</param>
        /// <returns></returns>
        public int GetRandomNum(int minNum, int maxNum)
        {
            int randomNumResult = 0;

            if (minNum == maxNum)
            {
                randomNumResult = minNum;
            }
            randomNumResult = Random.Range(minNum, maxNum + 1);
            return randomNumResult;
        }
    }
}