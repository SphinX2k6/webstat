using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.QuestMultiLine.QuestMultiLineData;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuestMultiLine
{
	// Token: 0x0200531F RID: 21279
	[NullableContext(1)]
	[Nullable(0)]
	public static class QuestMultiLineUtils
	{
		// Token: 0x060364D3 RID: 222419 RVA: 0x00DAFC18 File Offset: 0x00DADE18
		public static float ClampValue(float value, float min, float max)
		{
			return Math.Max(min, Math.Min(max, value));
		}

		// Token: 0x060364D4 RID: 222420 RVA: 0x00DAFC27 File Offset: 0x00DADE27
		public static string GetComponentIconTexture(QuestMultiLineComponentData component)
		{
			return QuestMultiLineUtils.GetIconForGender(component.ComponentIcon);
		}

		// Token: 0x060364D5 RID: 222421 RVA: 0x00DAFC34 File Offset: 0x00DADE34
		public static bool IsMultiPersonAvatar(QuestMultiLineComponentData component)
		{
			return component.ComponentIcon.Length == 0;
		}

		// Token: 0x060364D6 RID: 222422 RVA: 0x00DAFC40 File Offset: 0x00DADE40
		public static bool IsComponentClickable(QuestMultiLineComponentData component)
		{
			return component.Type == 1 || component.Type == 3;
		}

		// Token: 0x060364D7 RID: 222423 RVA: 0x00DAFC56 File Offset: 0x00DADE56
		public static string GetMultiPersonAvatarTexture(QuestMultiLineComponentData component)
		{
			return QuestMultiLineUtils.GetIconForGender(component.MultiPersonAvatar);
		}

		// Token: 0x060364D8 RID: 222424 RVA: 0x00DAFC64 File Offset: 0x00DADE64
		public static string GetIconForGender(string[] icons)
		{
			EPlayerGender playerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
			if (icons.Length < 2 || playerGender == EPlayerGender.None)
			{
				return icons[0];
			}
			return icons[(int)playerGender];
		}

		// Token: 0x060364D9 RID: 222425 RVA: 0x00DAFC90 File Offset: 0x00DADE90
		public static List<QuestMultiLineComponentData> GetBranchPageComponents([Nullable(2)] QuestMultiLineBranchPageData branchPageData)
		{
			if (branchPageData == null)
			{
				return new List<QuestMultiLineComponentData>();
			}
			List<QuestMultiLineBranchData> branchData = branchPageData.BranchData;
			if (branchData == null)
			{
				return new List<QuestMultiLineComponentData>();
			}
			List<QuestMultiLineComponentData> list = new List<QuestMultiLineComponentData>();
			foreach (QuestMultiLineBranchData questMultiLineBranchData in branchData)
			{
				foreach (QuestMultiLineComponentData item in questMultiLineBranchData.Components)
				{
					list.Add(item);
				}
			}
			return list;
		}

		// Token: 0x060364DA RID: 222426 RVA: 0x00DAFD3C File Offset: 0x00DADF3C
		public static Dictionary<int, bool> GetBranchPageFightAreas([Nullable(2)] QuestMultiLineBranchPageData branchPageData)
		{
			Dictionary<int, bool> dictionary = new Dictionary<int, bool>();
			if (branchPageData == null)
			{
				return dictionary;
			}
			List<QuestMultiLineBranchData> branchData = branchPageData.BranchData;
			if (branchData == null)
			{
				return dictionary;
			}
			foreach (QuestMultiLineBranchData questMultiLineBranchData in branchData)
			{
				foreach (int key in questMultiLineBranchData.FightingAreas)
				{
					dictionary[key] = true;
				}
			}
			return dictionary;
		}

		// Token: 0x060364DB RID: 222427 RVA: 0x00DAFDC4 File Offset: 0x00DADFC4
		public static bool IsBranchSelectTimePoint(QuestMultiLineTimePointData timePoint)
		{
			if (!timePoint.IsBranchTimePoint)
			{
				return false;
			}
			QuestBranchPageConfig? branchPageConfigById = QuestMultiLineConfig.GetBranchPageConfigById(timePoint.BranchPage);
			if (branchPageConfigById == null)
			{
				return false;
			}
			QuestNewModel instance = ModelBase<QuestNewModel>.Instance;
			foreach (IntVector2D intVector2D in branchPageConfigById.Value.QuestNodes())
			{
				global::Quest quest = instance.GetQuest(intVector2D.X);
				if (quest != null)
				{
					BaseBehaviorTree tree = quest.Tree;
					BehaviorNodeBase behaviorNodeBase = (tree != null) ? tree.GetNode(intVector2D.Y) : null;
					if (behaviorNodeBase != null && behaviorNodeBase.IsProcessing)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x060364DC RID: 222428 RVA: 0x00DAFE60 File Offset: 0x00DAE060
		public static bool IsComponentFinish(QuestMultiLineComponentData componentData)
		{
			int[] branchFinishQuestNode = componentData.BranchFinishQuestNode;
			if (branchFinishQuestNode.Length == 0)
			{
				return true;
			}
			int questId = branchFinishQuestNode[0];
			int nodeId = branchFinishQuestNode[1];
			global::Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(questId);
			if (quest == null)
			{
				return false;
			}
			BaseBehaviorTree tree = quest.Tree;
			BehaviorNodeBase behaviorNodeBase = (tree != null) ? tree.GetNode(nodeId) : null;
			return behaviorNodeBase != null && behaviorNodeBase.IsSuccess;
		}

		// Token: 0x060364DD RID: 222429 RVA: 0x00DAFEB8 File Offset: 0x00DAE0B8
		public static List<QuestMultiLineTimePointData> GetUnlockTimePointData(List<QuestMultiLineTimePointData> timePoints)
		{
			List<QuestMultiLineTimePointData> list = new List<QuestMultiLineTimePointData>();
			foreach (QuestMultiLineTimePointData questMultiLineTimePointData in timePoints)
			{
				list.Add(questMultiLineTimePointData);
				if (!questMultiLineTimePointData.IsUnLock)
				{
					return list;
				}
			}
			return list;
		}

		// Token: 0x060364DE RID: 222430 RVA: 0x00DAFF1C File Offset: 0x00DAE11C
		[return: Nullable(2)]
		public static QuestMultiLineTimePointData GetNextTimePoint(QuestMultiLineTimePointData timePoint)
		{
			List<QuestMultiLineTimePointData> questTimePoints = ModelBase<QuestMultiLineModel>.Instance.GetQuestTimePoints();
			int num = questTimePoints.IndexOf(timePoint);
			if (num >= 0 && num < questTimePoints.Count - 1)
			{
				return questTimePoints[num + 1];
			}
			return null;
		}

		// Token: 0x060364DF RID: 222431 RVA: 0x00DAFF58 File Offset: 0x00DAE158
		public static TArray<FVector2D> PointArrayToVectorArray(IReadOnlyList<global::Vector> points)
		{
			TArray<FVector2D> tarray = new TArray<FVector2D>();
			foreach (global::Vector vector in points)
			{
				tarray.Add(new FVector2D((float)vector.X, (float)vector.Y));
			}
			return tarray;
		}

		// Token: 0x060364E0 RID: 222432 RVA: 0x00DAFFBC File Offset: 0x00DAE1BC
		public static string GetPointSpritePath(QuestMultiLineTimePointData data)
		{
			if (!data.IsUnLock)
			{
				return "/Game/Aki/UI/UIResources/UiMissionMap/Atlas/SP_TImeBtnPointLock.SP_TImeBtnPointLock";
			}
			if (QuestMultiLineUtils.IsBranchSelectTimePoint(data))
			{
				return "/Game/Aki/UI/UIResources/UiMissionMap/Atlas/SP_TimeBtnPointSubNor.SP_TimeBtnPointSubNor";
			}
			return "/Game/Aki/UI/UIResources/UiMissionMap/Atlas/SP_TImeBtnPointNor.SP_TImeBtnPointNor";
		}

		// Token: 0x060364E1 RID: 222433 RVA: 0x00DAFFE0 File Offset: 0x00DAE1E0
		public static ITimePointSpritePaths GetPointSpritePaths(QuestMultiLineTimePointData data)
		{
			if (!data.IsUnLock)
			{
				return new TimePointSpritePaths
				{
					Idle = "/Game/Aki/UI/UIResources/UiMissionMap/Atlas/SP_TImeBtnPointLock.SP_TImeBtnPointLock",
					Hover = "/Game/Aki/UI/UIResources/UiMissionMap/Atlas/SP_TImeBtnPointLock.SP_TImeBtnPointLock",
					Pressed = "/Game/Aki/UI/UIResources/UiMissionMap/Atlas/SP_TImeBtnPointLock.SP_TImeBtnPointLock",
					Selected = "/Game/Aki/UI/UIResources/UiMissionMap/Atlas/SP_TImeBtnPointLock.SP_TImeBtnPointLock"
				};
			}
			if (data.IsBranchNode)
			{
				return new TimePointSpritePaths
				{
					Idle = "/Game/Aki/UI/UIResources/UiMissionMap/Atlas/SP_TimeBtnPointSubNor.SP_TimeBtnPointSubNor",
					Hover = "/Game/Aki/UI/UIResources/UiMissionMap/Atlas/SP_TimeBtnPointSubHold.SP_TimeBtnPointSubHold",
					Pressed = "/Game/Aki/UI/UIResources/UiMissionMap/Atlas/SP_TimeBtnPointSubPress.SP_TimeBtnPointSubPress",
					Selected = "/Game/Aki/UI/UIResources/UiMissionMap/Atlas/SP_TimeBtnPointSubSele.SP_TimeBtnPointSubSele"
				};
			}
			return new TimePointSpritePaths
			{
				Idle = "/Game/Aki/UI/UIResources/UiMissionMap/Atlas/SP_TImeBtnPointNor.SP_TImeBtnPointNor",
				Hover = "/Game/Aki/UI/UIResources/UiMissionMap/Atlas/SP_TimeBtnPointHold.SP_TimeBtnPointHold",
				Pressed = "/Game/Aki/UI/UIResources/UiMissionMap/Atlas/SP_TimeBtnPointPress.SP_TimeBtnPointPress",
				Selected = "/Game/Aki/UI/UIResources/UiMissionMap/Atlas/SP_TimeBtnPointSele.SP_TimeBtnPointSele"
			};
		}
	}
}
