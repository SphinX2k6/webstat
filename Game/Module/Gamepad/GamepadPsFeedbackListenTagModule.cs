using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Menu;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Gamepad
{
	// Token: 0x02005D04 RID: 23812
	[NullableContext(1)]
	[Nullable(0)]
	public class GamepadPsFeedbackListenTagModule
	{
		// Token: 0x0603C094 RID: 245908 RVA: 0x00F3AE62 File Offset: 0x00F39062
		public void Init()
		{
			this.AddEvents();
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				this.InitPsFeedbackTagSettings();
			}
		}

		// Token: 0x0603C095 RID: 245909 RVA: 0x00F3AE7C File Offset: 0x00F3907C
		public void Clear()
		{
			this.RemoveEvents();
			this.ClearListenTagData();
		}

		// Token: 0x0603C096 RID: 245910 RVA: 0x00F3AE8C File Offset: 0x00F3908C
		private void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add<global::EInputControllerType, global::EInputControllerType>(EEventName.InputControllerChange, new Action<global::EInputControllerType, global::EInputControllerType>(this.OnInputControllerChange));
			Singleton<EventSystem>.Instance.Add<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
			Singleton<EventSystem>.Instance.Add<IReadOnlyList<InputDistributeTag>>(EEventName.OnInputDistributeTagChanged, new Action<IReadOnlyList<InputDistributeTag>>(this.OnInputDistributeTagChanged));
			Singleton<EventSystem>.Instance.Add<KeySettingRowData, CSharpScript.Game.Module.Menu.EInputControllerType>(EEventName.OnCommonKeySettingKeyChange, new Action<KeySettingRowData, CSharpScript.Game.Module.Menu.EInputControllerType>(this.OnCommonKeySettingKeyChange));
			ControllerBase<InputDistributeController>.Instance.BindAction("组合主键", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputCombineButton));
		}

		// Token: 0x0603C097 RID: 245911 RVA: 0x00F3AF24 File Offset: 0x00F39124
		private void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove<global::EInputControllerType, global::EInputControllerType>(EEventName.InputControllerChange, new Action<global::EInputControllerType, global::EInputControllerType>(this.OnInputControllerChange));
			Singleton<EventSystem>.Instance.Remove<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
			Singleton<EventSystem>.Instance.Remove<IReadOnlyList<InputDistributeTag>>(EEventName.OnInputDistributeTagChanged, new Action<IReadOnlyList<InputDistributeTag>>(this.OnInputDistributeTagChanged));
			Singleton<EventSystem>.Instance.Remove<KeySettingRowData, CSharpScript.Game.Module.Menu.EInputControllerType>(EEventName.OnCommonKeySettingKeyChange, new Action<KeySettingRowData, CSharpScript.Game.Module.Menu.EInputControllerType>(this.OnCommonKeySettingKeyChange));
			ControllerBase<InputDistributeController>.Instance.UnBindAction("组合主键", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputCombineButton));
		}

		// Token: 0x0603C098 RID: 245912 RVA: 0x00F3AFBC File Offset: 0x00F391BC
		private void InitPsFeedbackTagSettings()
		{
			if (this.IsInitListenTags)
			{
				return;
			}
			this.IsInitListenTags = true;
			IReadOnlyList<PsFeedback> allPsFeedbackConfig = ConfigBase<GamepadConfig>.Instance.GetAllPsFeedbackConfig();
			if (allPsFeedbackConfig != null)
			{
				foreach (PsFeedback psFeedback in allPsFeedbackConfig)
				{
					if (this.GamepadPsFeedbackListenTagsMap == null)
					{
						this.GamepadPsFeedbackListenTagsMap = new Dictionary<int, GamepadPsFeedbackListenTagModule.PsFeedbackTagData>();
					}
					if (!string.IsNullOrEmpty(psFeedback.ListenTag))
					{
						int tagIdByName = GameplayTagUtils.GetTagIdByName(psFeedback.ListenTag);
						this.GamepadPsFeedbackListenTagsMap[tagIdByName] = new GamepadPsFeedbackListenTagModule.PsFeedbackTagData(psFeedback.Id, psFeedback.Priority);
					}
				}
			}
		}

		// Token: 0x0603C099 RID: 245913 RVA: 0x00F3B068 File Offset: 0x00F39268
		[NullableContext(2)]
		private void InitEntityListenTags(Entity entity)
		{
			if (entity == null || this.GamepadPsFeedbackListenTagsMap == null)
			{
				return;
			}
			BaseTagComponent component = entity.GetComponent<BaseTagComponent>();
			int count = this.GamepadPsFeedbackListenTagsMap.Count;
			int num = 0;
			foreach (KeyValuePair<int, GamepadPsFeedbackListenTagModule.PsFeedbackTagData> keyValuePair in this.GamepadPsFeedbackListenTagsMap)
			{
				int key = keyValuePair.Key;
				GamepadPsFeedbackListenTagModule.PsFeedbackTagData value = keyValuePair.Value;
				ITagTask tagTask = (component != null) ? component.ListenForTagAddOrRemove(new int?(key), new BaseTagComponent.TTagSwitchedCallback(this.OnPsFeedbackListenTagChanged), null) : null;
				if (tagTask != null)
				{
					if (this.GamepadPsFeedbackListenTasks == null)
					{
						this.GamepadPsFeedbackListenTasks = new List<ITagTask>();
					}
					this.GamepadPsFeedbackListenTasks.Add(tagTask);
				}
				if (component != null && component.HasTag(key))
				{
					this.AddFeedbackTagData(value, false);
				}
				num++;
				if (num == count)
				{
					List<GamepadPsFeedbackListenTagModule.PsFeedbackTagData> gamepadPsFeedbackTagDataQueue = this.GamepadPsFeedbackTagDataQueue;
					if (gamepadPsFeedbackTagDataQueue != null)
					{
						gamepadPsFeedbackTagDataQueue.Sort((GamepadPsFeedbackListenTagModule.PsFeedbackTagData a, GamepadPsFeedbackListenTagModule.PsFeedbackTagData b) => b.Priority - a.Priority);
					}
					this.ApplyFeedbackTagData();
				}
			}
		}

		// Token: 0x0603C09A RID: 245914 RVA: 0x00F3B18C File Offset: 0x00F3938C
		private bool AddFeedbackTagData(GamepadPsFeedbackListenTagModule.PsFeedbackTagData tagData, bool needSort = true)
		{
			List<GamepadPsFeedbackListenTagModule.PsFeedbackTagData> list = this.GamepadPsFeedbackTagDataQueue;
			if (list == null)
			{
				list = new List<GamepadPsFeedbackListenTagModule.PsFeedbackTagData>();
				this.GamepadPsFeedbackTagDataQueue = list;
			}
			if (!list.Contains(tagData))
			{
				GamepadPsFeedbackListenTagModule.PsFeedbackTagData psFeedbackTagData = (list.Count > 0) ? list[0] : null;
				list.Add(tagData);
				if (needSort)
				{
					list.Sort((GamepadPsFeedbackListenTagModule.PsFeedbackTagData a, GamepadPsFeedbackListenTagModule.PsFeedbackTagData b) => b.Priority - a.Priority);
				}
				return psFeedbackTagData == null || psFeedbackTagData.FeedbackId != list[0].FeedbackId;
			}
			return false;
		}

		// Token: 0x0603C09B RID: 245915 RVA: 0x00F3B21C File Offset: 0x00F3941C
		private bool RemoveFeedbackTagData(GamepadPsFeedbackListenTagModule.PsFeedbackTagData tagData, bool needSort = true)
		{
			List<GamepadPsFeedbackListenTagModule.PsFeedbackTagData> gamepadPsFeedbackTagDataQueue = this.GamepadPsFeedbackTagDataQueue;
			if (gamepadPsFeedbackTagDataQueue != null && gamepadPsFeedbackTagDataQueue.Contains(tagData))
			{
				int num = gamepadPsFeedbackTagDataQueue.IndexOf(tagData);
				gamepadPsFeedbackTagDataQueue.RemoveAt(num);
				if (needSort)
				{
					gamepadPsFeedbackTagDataQueue.Sort((GamepadPsFeedbackListenTagModule.PsFeedbackTagData a, GamepadPsFeedbackListenTagModule.PsFeedbackTagData b) => b.Priority - a.Priority);
				}
				return num == 0;
			}
			return false;
		}

		// Token: 0x0603C09C RID: 245916 RVA: 0x00F3B27C File Offset: 0x00F3947C
		private void ApplyFeedbackTagData()
		{
			List<GamepadPsFeedbackListenTagModule.PsFeedbackTagData> gamepadPsFeedbackTagDataQueue = this.GamepadPsFeedbackTagDataQueue;
			if (gamepadPsFeedbackTagDataQueue == null)
			{
				return;
			}
			if (gamepadPsFeedbackTagDataQueue.Count > 0)
			{
				GamepadPsFeedbackListenTagModule.PsFeedbackTagData psFeedbackTagData = gamepadPsFeedbackTagDataQueue[0];
				if (this.CurrentTagDataFeedbackId != psFeedbackTagData.FeedbackId)
				{
					this.CurrentTagDataFeedbackId = psFeedbackTagData.FeedbackId;
					this.TryRefreshFeedback();
					return;
				}
			}
			else
			{
				this.CurrentTagDataFeedbackId = "";
				this.StopFeedback();
			}
		}

		// Token: 0x0603C09D RID: 245917 RVA: 0x00F3B2DC File Offset: 0x00F394DC
		private void ClearListenTagData()
		{
			if (this.GamepadPsFeedbackListenTasks != null)
			{
				foreach (ITagTask tagTask in this.GamepadPsFeedbackListenTasks)
				{
					tagTask.EndTask();
				}
				this.GamepadPsFeedbackListenTasks.Clear();
			}
			if (this.GamepadPsFeedbackTagDataQueue != null)
			{
				this.GamepadPsFeedbackTagDataQueue.Clear();
			}
			this.CurrentTagDataFeedbackId = "";
		}

		// Token: 0x0603C09E RID: 245918 RVA: 0x00F3B360 File Offset: 0x00F39560
		private void OnPsFeedbackListenTagChanged(int tagId, bool tagExist)
		{
			GamepadPsFeedbackListenTagModule.PsFeedbackTagData tagData;
			if (this.GamepadPsFeedbackListenTagsMap != null && this.GamepadPsFeedbackListenTagsMap.TryGetValue(tagId, out tagData) && (tagExist ? this.AddFeedbackTagData(tagData, true) : this.RemoveFeedbackTagData(tagData, true)))
			{
				this.ApplyFeedbackTagData();
			}
		}

		// Token: 0x0603C09F RID: 245919 RVA: 0x00F3B3A2 File Offset: 0x00F395A2
		private void OnInputControllerChange(global::EInputControllerType last, global::EInputControllerType now)
		{
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				this.InitPsFeedbackTagSettings();
				TsBaseCharacter baseCharacter = Global.BaseCharacter;
				Entity entity;
				if (baseCharacter == null)
				{
					entity = null;
				}
				else
				{
					CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
					entity = ((characterActorComponent != null) ? characterActorComponent.Entity : null);
				}
				this.InitEntityListenTags(entity);
				return;
			}
			this.ClearListenTagData();
		}

		// Token: 0x0603C0A0 RID: 245920 RVA: 0x00F3B3E0 File Offset: 0x00F395E0
		private void OnChangeRole(EntityHandle newEntity, EntityHandle oldEntity)
		{
			this.ClearListenTagData();
			if (!Singleton<Info>.Instance.IsInGamepad())
			{
				return;
			}
			this.StopFeedback();
			this.InitEntityListenTags(newEntity.Entity);
		}

		// Token: 0x0603C0A1 RID: 245921 RVA: 0x00F3B407 File Offset: 0x00F39607
		private void OnInputDistributeTagChanged(IReadOnlyList<InputDistributeTag> tagList)
		{
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				this.TryRefreshFeedback();
			}
		}

		// Token: 0x0603C0A2 RID: 245922 RVA: 0x00F3B41C File Offset: 0x00F3961C
		private void OnCommonKeySettingKeyChange(KeySettingRowData keyData, CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType)
		{
			if (inputControllerType == CSharpScript.Game.Module.Menu.EInputControllerType.Gamepad && !string.IsNullOrEmpty(this.CurrentFeedbackId))
			{
				PsFeedback? psFeedbackReason = ConfigBase<GamepadConfig>.Instance.GetPsFeedbackReason(this.CurrentFeedbackId);
				if (keyData.GetActionOrAxisName() == ((psFeedbackReason != null) ? psFeedbackReason.GetValueOrDefault().ActionName : null))
				{
					this.TryRefreshFeedback();
				}
			}
		}

		// Token: 0x0603C0A3 RID: 245923 RVA: 0x00F3B479 File Offset: 0x00F39679
		private void OnInputCombineButton(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification identification)
		{
			this.IsInCombinationKey = (actionType == InputDistributeDefine.EActionType.Press);
			this.TryRefreshFeedback();
		}

		// Token: 0x0603C0A4 RID: 245924 RVA: 0x00F3B48B File Offset: 0x00F3968B
		private void TryRefreshFeedback()
		{
			if (!this.CheckFeedbackCondition())
			{
				this.StopFeedback();
				return;
			}
			this.RefreshFeedback();
		}

		// Token: 0x0603C0A5 RID: 245925 RVA: 0x00F3B4A2 File Offset: 0x00F396A2
		private bool CheckFeedbackCondition()
		{
			return this.CheckInputDistribute() && !this.IsInCombinationKey;
		}

		// Token: 0x0603C0A6 RID: 245926 RVA: 0x00F3B4B9 File Offset: 0x00F396B9
		private bool CheckInputDistribute()
		{
			return ModelBase<InputDistributeModel>.Instance.IsTagMatchAnyCurrentInputTag("FightInputRoot", false);
		}

		// Token: 0x0603C0A7 RID: 245927 RVA: 0x00F3B4CC File Offset: 0x00F396CC
		private void RefreshFeedback()
		{
			string currentTagDataFeedbackId = this.CurrentTagDataFeedbackId;
			if (string.IsNullOrEmpty(currentTagDataFeedbackId))
			{
				this.StopFeedback();
				return;
			}
			if (this.CurrentFeedbackId == currentTagDataFeedbackId)
			{
				return;
			}
			this.CurrentFeedbackId = currentTagDataFeedbackId;
			ControllerBase<GamepadController>.Instance.TryAddFeedbackReason(EGamepadPsFeedbackReason.ListenTag, currentTagDataFeedbackId);
		}

		// Token: 0x0603C0A8 RID: 245928 RVA: 0x00F3B511 File Offset: 0x00F39711
		private void StopFeedback()
		{
			if (string.IsNullOrEmpty(this.CurrentFeedbackId))
			{
				return;
			}
			this.CurrentFeedbackId = "";
			ControllerBase<GamepadController>.Instance.RemoveFeedbackReason(EGamepadPsFeedbackReason.ListenTag);
		}

		// Token: 0x04021B99 RID: 138137
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<int, GamepadPsFeedbackListenTagModule.PsFeedbackTagData> GamepadPsFeedbackListenTagsMap;

		// Token: 0x04021B9A RID: 138138
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<GamepadPsFeedbackListenTagModule.PsFeedbackTagData> GamepadPsFeedbackTagDataQueue;

		// Token: 0x04021B9B RID: 138139
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<ITagTask> GamepadPsFeedbackListenTasks;

		// Token: 0x04021B9C RID: 138140
		private bool IsInitListenTags;

		// Token: 0x04021B9D RID: 138141
		private string CurrentTagDataFeedbackId = "";

		// Token: 0x04021B9E RID: 138142
		private string CurrentFeedbackId = "";

		// Token: 0x04021B9F RID: 138143
		private bool IsInCombinationKey;

		// Token: 0x0200BD74 RID: 48500
		[Nullable(0)]
		private class PsFeedbackTagData
		{
			// Token: 0x1700AA2E RID: 43566
			// (get) Token: 0x0604DEE8 RID: 319208 RVA: 0x01586E02 File Offset: 0x01585002
			// (set) Token: 0x0604DEE9 RID: 319209 RVA: 0x01586E0A File Offset: 0x0158500A
			public string FeedbackId { get; set; }

			// Token: 0x1700AA2F RID: 43567
			// (get) Token: 0x0604DEEA RID: 319210 RVA: 0x01586E13 File Offset: 0x01585013
			// (set) Token: 0x0604DEEB RID: 319211 RVA: 0x01586E1B File Offset: 0x0158501B
			public int Priority { get; set; }

			// Token: 0x0604DEEC RID: 319212 RVA: 0x01586E24 File Offset: 0x01585024
			public PsFeedbackTagData(string feedbackId, int priority)
			{
				this.FeedbackId = feedbackId;
				this.Priority = priority;
			}
		}
	}
}
