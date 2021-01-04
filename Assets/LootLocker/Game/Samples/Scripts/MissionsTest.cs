﻿using LootLockerRequests;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LootLockerExample
{
    public class MissionsTest : MonoBehaviour
    {
        public int missionId;
        public string finishTime;
        public string finishScore;
        public List<CheckpointTimes> checkpointTimes;
        public string startingMissionSignature;
        public string playerId;

        [ContextMenu("GettingAllMissions")]
        public void GettingAllMissions()
        {

            LootLockerSDKManager.GettingAllMissions((response) =>
            {
                if (response.success)
                {
                    LootLockerSDKManager.DebugMessage("Successful");
                }
                else
                {
                    LootLockerSDKManager.DebugMessage("failed: " + response.Error, true);
                }
            });
        }

        [ContextMenu("GettingASingleMission")]
        public void GettingASingleMission()
        {

            LootLockerSDKManager.GettingASingleMission(missionId, (response) =>
            {
                if (response.success)
                {
                    LootLockerSDKManager.DebugMessage("Successful");
                }
                else
                {
                    LootLockerSDKManager.DebugMessage("failed: " + response.Error, true);
                }
            });
        }

        [ContextMenu("StartingAMission")]
        public void StartingAMission()
        {

            LootLockerSDKManager.StartingAMission(missionId, (response) =>
            {
                if (response.success)
                {
                    LootLockerSDKManager.DebugMessage("Successful");
                }
                else
                {
                    LootLockerSDKManager.DebugMessage("failed: " + response.Error, true);
                }
            });
        }

        [ContextMenu("FinishingAMission")]
        public void FinishingAMission()
        {
            FinishingPayload finishingPayload = new FinishingPayload()
            {
                finish_score = finishScore,
                finish_time = finishTime,
                checkpoint_times = checkpointTimes.ToArray()
            };
            LootLockerSDKManager.FinishingAMission(missionId, startingMissionSignature, playerId, finishingPayload, (response) =>
            {
                if (response.success)
                {
                    LootLockerSDKManager.DebugMessage("Successful");
                }
                else
                {
                    LootLockerSDKManager.DebugMessage("failed: " + response.Error, true);
                }
            });
        }
    }
}