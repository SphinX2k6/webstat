using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using CSharpScript.Game.Module.SkillButtonUi.Custom;

namespace CSharpScript.Game.Module.SkillButtonUi
{
	// Token: 0x02004F83 RID: 20355
	[NullableContext(2)]
	[Nullable(0)]
	public class SkillButtonFollowerEntityData
	{
		// Token: 0x06034891 RID: 215185 RVA: 0x00D29C6C File Offset: 0x00D27E6C
		[NullableContext(1)]
		public void Init(EntityHandle entityHandle, bool bEnable)
		{
			this.EntityHandle = entityHandle;
			WorldEntity entity = entityHandle.Entity;
			this.IsEnable = bEnable;
			CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
			this.PbDataId = component.GetPbDataId();
			this.AttributeComponent = entity.GetComponent<BaseAttributeComponent>();
			this.GameplayTagComponent = entity.GetComponent<BaseTagComponent>();
			this.SkillComponent = entity.GetComponent<CharacterSkillComponent>();
			SkillButtonConfig instance = ConfigBase<SkillButtonConfig>.Instance;
			this.SkillButtonConfigList = instance.GetAllSkillFollowerButtonConfig(this.PbDataId);
			this.NewAllSkillButtonData();
			this.AddEntityEvents();
			if (this.IsEnable)
			{
				this.RefreshAllSkillButton();
			}
		}

		// Token: 0x06034892 RID: 215186 RVA: 0x00D29CF7 File Offset: 0x00D27EF7
		public void SetEnable(bool bEnable)
		{
			this.IsEnable = bEnable;
			this.RefreshAllSkillButton();
		}

		// Token: 0x06034893 RID: 215187 RVA: 0x00D29D08 File Offset: 0x00D27F08
		public void RefreshAllSkillButton()
		{
			if (this.SkillButtonDataMap != null)
			{
				this.EnableNextTick();
				foreach (SkillButtonData item in this.SkillButtonDataMap.Values)
				{
					this.SkillIdChanged.Add(item);
				}
			}
		}

		// Token: 0x06034894 RID: 215188 RVA: 0x00D29D74 File Offset: 0x00D27F74
		public void Clear()
		{
			this.ClearAllEvent();
			foreach (SkillButtonData skillButtonData in this.SkillButtonDataMap.Values)
			{
				skillButtonData.Reset();
			}
			this.SkillButtonDataMap = null;
			this.AttributeIdSkillButtonMapping = null;
			this.AttributeIdTagSkillButtonMapping = null;
			this.DisableTagSkillButtonMapping = null;
			this.DisableSkillIdTagSkillButtonMapping = null;
			this.NotOccupyTagSkillButtonMapping = null;
			this.DynamicEffectTagSkillButtonMapping = null;
			this.SkillIconTagSkillButtonMapping = null;
			this.SkillIdTagSkillButtonMapping = null;
			foreach (ITagTask tagTask in this.TagSignificantChangedWithTagTasks)
			{
				if (tagTask != null)
				{
					tagTask.EndTask();
				}
			}
			this.TagSignificantChangedWithTagTasks = null;
			this.AttributeChangedCallbackMap = null;
			this.CustomHandleSkillButtonMapping = null;
			this.EntityHandle = null;
			this.PbDataId = 0;
			this.AttributeComponent = null;
			this.GameplayTagComponent = null;
			this.SkillComponent = null;
			this.SkillButtonConfigList = null;
		}

		// Token: 0x06034895 RID: 215189 RVA: 0x00D29E94 File Offset: 0x00D28094
		private void NewAllSkillButtonData()
		{
			if (this.PbDataId <= 0)
			{
				return;
			}
			IReadOnlyList<SkillFollowerButton> skillButtonConfigList = this.SkillButtonConfigList;
			if (skillButtonConfigList != null)
			{
				foreach (SkillFollowerButton config in skillButtonConfigList)
				{
					ESkillButtonType buttonType = (ESkillButtonType)config.ButtonType;
					SkillButtonData skillButtonData = new SkillButtonData();
					this.SkillButtonDataMap[buttonType] = skillButtonData;
					this.InitSkillButtonData(skillButtonData, config);
				}
			}
		}

		// Token: 0x06034896 RID: 215190 RVA: 0x00D29F10 File Offset: 0x00D28110
		[NullableContext(1)]
		private void InitSkillButtonData(SkillButtonData skillButtonData, SkillFollowerButton config)
		{
			skillButtonData.Refresh(this.EntityHandle, config, ESkillButtonConfigType.Follower, null);
			this.AttributeIdSkillButtonMapping.AddSingle(skillButtonData.AttributeId, skillButtonData);
			this.AttributeIdSkillButtonMapping.AddSingle(skillButtonData.MaxAttributeId, skillButtonData);
			foreach (int key in skillButtonData.AttributeIdTagMap.Keys)
			{
				this.AttributeIdTagSkillButtonMapping.AddSingle(key, skillButtonData);
			}
			this.DisableTagSkillButtonMapping.Add(skillButtonData.GetDisableTagIds(), skillButtonData);
			this.DisableSkillIdTagSkillButtonMapping.Add(skillButtonData.GetDisableSkillIdTagIds().Keys, skillButtonData);
			this.NotOccupyTagSkillButtonMapping.Add(skillButtonData.GetNotOccupyTagIds(), skillButtonData);
			this.DynamicEffectTagSkillButtonMapping.Add(skillButtonData.DynamicEffectTagIdMap.Keys, skillButtonData);
			this.SkillIconTagSkillButtonMapping.Add(skillButtonData.SkillIconTagIds, skillButtonData);
			foreach (int key2 in skillButtonData.SkillIdTagMap.Keys)
			{
				this.SkillIdTagSkillButtonMapping.AddSingle(key2, skillButtonData);
			}
			if (skillButtonData.CustomHandle != null && skillButtonData.CustomHandle.TagIds.Count > 0)
			{
				this.CustomHandleSkillButtonMapping.Add(skillButtonData.CustomHandle.TagIds, skillButtonData);
			}
		}

		// Token: 0x06034897 RID: 215191 RVA: 0x00D2A094 File Offset: 0x00D28294
		private void AddEntityEvents()
		{
			this.ListenEntityTag();
			this.ListenEntityAttribute();
		}

		// Token: 0x06034898 RID: 215192 RVA: 0x00D2A0A4 File Offset: 0x00D282A4
		private void ListenEntityTag()
		{
			if (this.PbDataId <= 0)
			{
				return;
			}
			foreach (SkillButtonData skillButtonData in this.SkillButtonDataMap.Values)
			{
				if (skillButtonData.GetEntityHandle() != null)
				{
					foreach (int tag in skillButtonData.AttributeIdTagMap.Keys)
					{
						this.ListenForTagSignificantChangedWithTag(tag, new Action<int, bool>(this.OnAttributeIdTagChanged));
					}
					foreach (int tag2 in skillButtonData.GetDisableTagIds())
					{
						this.ListenForTagSignificantChangedWithTag(tag2, new Action<int, bool>(this.OnDisableTagChanged));
					}
					foreach (int tag3 in skillButtonData.GetDisableSkillIdTagIds().Keys)
					{
						this.ListenForTagSignificantChangedWithTag(tag3, new Action<int, bool>(this.OnDisableSkillIdTagChanged));
					}
					foreach (int tag4 in skillButtonData.GetNotOccupyTagIds())
					{
						this.ListenForTagSignificantChangedWithTag(tag4, new Action<int, bool>(this.OnNotOccupyTagChanged));
					}
					foreach (int tag5 in skillButtonData.SkillIdTagMap.Keys)
					{
						this.ListenForTagSignificantChangedWithTag(tag5, new Action<int, bool>(this.OnSkillTagChanged));
					}
					foreach (int tag6 in skillButtonData.SkillIconTagIds)
					{
						this.ListenForTagSignificantChangedWithTag(tag6, new Action<int, bool>(this.OnSkillIconTagChanged));
					}
					foreach (int tag7 in skillButtonData.DynamicEffectTagIdMap.Keys)
					{
						this.ListenForTagSignificantChangedWithTag(tag7, new Action<int, bool>(this.OnDynamicEffectTagChanged));
					}
					SkillButtonCustomHandleBase customHandle = skillButtonData.CustomHandle;
					List<int> list = (customHandle != null) ? customHandle.TagIds : null;
					if (list != null)
					{
						foreach (int tagId in list)
						{
							this.ListenForTagAnyCountChanged(tagId, new Action<int, int, int, int>(this.OnCustomTagCountChanged));
						}
					}
				}
			}
		}

		// Token: 0x06034899 RID: 215193 RVA: 0x00D2A404 File Offset: 0x00D28604
		private void ListenEntityAttribute()
		{
			foreach (SkillButtonData skillButtonData in this.SkillButtonDataMap.Values)
			{
				if (skillButtonData.GetEntityHandle() != null)
				{
					EAttributeType attributeId = skillButtonData.AttributeId;
					EAttributeType maxAttributeId = skillButtonData.MaxAttributeId;
					if (attributeId > EAttributeType.None && maxAttributeId > EAttributeType.None)
					{
						this.ListenForAttributeChanged(attributeId, new Action<EAttributeType, float, float>(this.OnAttributeChanged));
						this.ListenForAttributeChanged(maxAttributeId, new Action<EAttributeType, float, float>(this.OnAttributeChanged));
					}
				}
			}
		}

		// Token: 0x0603489A RID: 215194 RVA: 0x00D2A49C File Offset: 0x00D2869C
		[NullableContext(1)]
		private void ListenForTagSignificantChangedWithTag(int tag, Action<int, bool> callback)
		{
			int? num = new int?(tag);
			if (num == null)
			{
				return;
			}
			ITagTask tagTask = this.GameplayTagComponent.ListenForTagAddOrRemove(new int?(num.Value), new BaseTagComponent.TTagSwitchedCallback(callback.Invoke), null);
			if (tagTask == null)
			{
				return;
			}
			this.TagSignificantChangedWithTagTasks.Add(tagTask);
		}

		// Token: 0x0603489B RID: 215195 RVA: 0x00D2A4F4 File Offset: 0x00D286F4
		[NullableContext(1)]
		private void ListenForTagAnyCountChanged(int tagId, Action<int, int, int, int> callback)
		{
			if (tagId == 0)
			{
				return;
			}
			ITagTask tagTask = this.GameplayTagComponent.ListenForTagAnyCountChanged(tagId, new BaseTagComponent.TTagChangedCallback(callback.Invoke));
			if (tagTask == null)
			{
				return;
			}
			this.TagSignificantChangedWithTagTasks.Add(tagTask);
		}

		// Token: 0x0603489C RID: 215196 RVA: 0x00D2A52F File Offset: 0x00D2872F
		[NullableContext(1)]
		private void ListenForAttributeChanged(EAttributeType attributeId, Action<EAttributeType, float, float> onAttributeChanged)
		{
			BaseAttributeComponent attributeComponent = this.AttributeComponent;
			if (attributeComponent != null)
			{
				attributeComponent.AddListener(attributeId, onAttributeChanged, "SkillButtonUiController");
			}
			this.AttributeChangedCallbackMap[attributeId] = onAttributeChanged;
		}

		// Token: 0x0603489D RID: 215197 RVA: 0x00D2A556 File Offset: 0x00D28756
		private void EnableNextTick()
		{
			if (this.NextTickTimerId != null)
			{
				return;
			}
			this.NextTickTimerId = TimerSystem.Instance.Next(new TTimerAction(this.NextTick), SkillButtonFollowerEntityData.NextTickStat, null);
		}

		// Token: 0x0603489E RID: 215198 RVA: 0x00D2A584 File Offset: 0x00D28784
		private void ClearNextTick()
		{
			if (this.NextTickTimerId != null)
			{
				return;
			}
			if (TimerSystem.Instance.Has(this.NextTickTimerId))
			{
				TimerSystem.Instance.Remove(this.NextTickTimerId);
			}
			this.NextTickTimerId = null;
			this.EnableChanged.Clear();
			this.VisibleChanged.Clear();
			this.SkillIdChanged.Clear();
			this.SkillIconChanged.Clear();
			this.DynamicEffectChanged.Clear();
			this.SkillCdChanged.Clear();
			this.AttributeChanged.Clear();
		}

		// Token: 0x0603489F RID: 215199 RVA: 0x00D2A614 File Offset: 0x00D28814
		private void NextTick(float _)
		{
			this.NextTickTimerId = null;
			foreach (SkillButtonData skillButtonData in this.EnableChanged)
			{
				Singleton<EventSystem>.Instance.Emit<ESkillButtonType, int>(EEventName.OnSkillButtonEnableRefresh, skillButtonData.GetButtonType(), -1);
			}
			this.EnableChanged.Clear();
			foreach (SkillButtonData skillButtonData2 in this.VisibleChanged)
			{
				Singleton<EventSystem>.Instance.Emit<ESkillButtonType>(EEventName.OnSkillButtonVisibleRefresh, skillButtonData2.GetButtonType());
			}
			this.VisibleChanged.Clear();
			foreach (SkillButtonData skillButtonData3 in this.SkillIdChanged)
			{
				Singleton<EventSystem>.Instance.Emit<ESkillButtonType>(EEventName.OnSkillButtonSkillIdRefresh, skillButtonData3.GetButtonType());
			}
			this.SkillIdChanged.Clear();
			foreach (SkillButtonData skillButtonData4 in this.SkillIconChanged)
			{
				Singleton<EventSystem>.Instance.Emit<ESkillButtonType>(EEventName.OnSkillButtonIconPathRefresh, skillButtonData4.GetButtonType());
			}
			this.SkillIconChanged.Clear();
			foreach (SkillButtonData skillButtonData5 in this.DynamicEffectChanged)
			{
				Singleton<EventSystem>.Instance.Emit<ESkillButtonType>(EEventName.OnSkillButtonDynamicEffectRefresh, skillButtonData5.GetButtonType());
			}
			this.DynamicEffectChanged.Clear();
			foreach (SkillButtonData skillButtonData6 in this.SkillCdChanged)
			{
				Singleton<EventSystem>.Instance.Emit<ESkillButtonType>(EEventName.OnSkillButtonCdRefresh, skillButtonData6.GetButtonType());
			}
			this.SkillCdChanged.Clear();
			foreach (SkillButtonData skillButtonData7 in this.AttributeChanged)
			{
				Singleton<EventSystem>.Instance.Emit<ESkillButtonType>(EEventName.OnSkillButtonAttributeRefresh, skillButtonData7.GetButtonType());
			}
			this.AttributeChanged.Clear();
			if (this.SkillButtonDataRefresh)
			{
				Singleton<EventSystem>.Instance.Emit<ESkillButtonRefreshReason>(EEventName.OnSkillButtonDataRefresh, this.SkillButtonDataRefreshReason);
				this.SkillButtonDataRefresh = false;
			}
		}

		// Token: 0x060348A0 RID: 215200 RVA: 0x00D2A8E0 File Offset: 0x00D28AE0
		public void RefreshSkillButtonData(ESkillButtonRefreshReason refreshReason)
		{
			if (this.SkillButtonDataRefresh)
			{
				if (refreshReason < this.SkillButtonDataRefreshReason)
				{
					this.SkillButtonDataRefreshReason = refreshReason;
				}
				return;
			}
			this.SkillButtonDataRefresh = true;
			this.SkillButtonDataRefreshReason = refreshReason;
			this.EnableNextTick();
		}

		// Token: 0x060348A1 RID: 215201 RVA: 0x00D2A910 File Offset: 0x00D28B10
		private void OnAttributeIdTagChanged(int tagId, bool tagExist)
		{
			HashSet<SkillButtonData> hashSet = this.AttributeIdTagSkillButtonMapping.Get(tagId);
			if (hashSet == null)
			{
				return;
			}
			foreach (SkillButtonData skillButtonData in hashSet)
			{
				EAttributeType attributeId = skillButtonData.AttributeId;
				EAttributeType maxAttributeId = skillButtonData.MaxAttributeId;
				skillButtonData.RefreshAttributeId();
				EAttributeType attributeId2 = skillButtonData.AttributeId;
				EAttributeType maxAttributeId2 = skillButtonData.MaxAttributeId;
				if (attributeId != attributeId2 || maxAttributeId != maxAttributeId2)
				{
					skillButtonData.RefreshFrameSpriteColor();
					this.AttributeIdSkillButtonMapping.RemoveSingle(attributeId, skillButtonData);
					this.AttributeIdSkillButtonMapping.RemoveSingle(maxAttributeId, skillButtonData);
					if (attributeId2 > EAttributeType.None)
					{
						this.AttributeIdSkillButtonMapping.AddSingle(attributeId2, skillButtonData);
						this.AttributeIdSkillButtonMapping.AddSingle(maxAttributeId2, skillButtonData);
						if (!this.AttributeChangedCallbackMap.ContainsKey(attributeId2))
						{
							this.ListenForAttributeChanged(attributeId2, new Action<EAttributeType, float, float>(this.OnAttributeChanged));
						}
						if (!this.AttributeChangedCallbackMap.ContainsKey(maxAttributeId2))
						{
							this.ListenForAttributeChanged(maxAttributeId2, new Action<EAttributeType, float, float>(this.OnAttributeChanged));
						}
					}
					bool flag = skillButtonData.IsEnable();
					skillButtonData.RefreshIsEnable();
					this.AttributeChanged.Add(skillButtonData);
					bool flag2 = skillButtonData.IsEnable();
					if (flag != flag2)
					{
						this.EnableChanged.Add(skillButtonData);
					}
					this.EnableNextTick();
				}
			}
		}

		// Token: 0x060348A2 RID: 215202 RVA: 0x00D2AA70 File Offset: 0x00D28C70
		private void OnDisableTagChanged(int tagId, bool tagExist)
		{
			HashSet<SkillButtonData> skillButtonDataByDisableTag = this.GetSkillButtonDataByDisableTag(tagId);
			if (skillButtonDataByDisableTag == null)
			{
				return;
			}
			foreach (SkillButtonData skillButtonData in skillButtonDataByDisableTag)
			{
				bool flag = skillButtonData.IsEnable();
				if (flag == tagExist)
				{
					bool flag2;
					if (tagExist)
					{
						skillButtonData.SetEnable(false, ESkillButtonDisableReason.DisableTag);
						flag2 = true;
					}
					else
					{
						skillButtonData.RefreshIsEnable();
						flag2 = (skillButtonData.IsEnable() != flag);
					}
					if (this.IsEnable && flag2)
					{
						this.EnableChanged.Add(skillButtonData);
						this.EnableNextTick();
					}
				}
			}
		}

		// Token: 0x060348A3 RID: 215203 RVA: 0x00D2AB14 File Offset: 0x00D28D14
		private void OnDisableSkillIdTagChanged(int tagId, bool tagExist)
		{
			HashSet<SkillButtonData> skillButtonDataByDisableSkillIdTag = this.GetSkillButtonDataByDisableSkillIdTag(tagId);
			if (skillButtonDataByDisableSkillIdTag == null)
			{
				return;
			}
			foreach (SkillButtonData skillButtonData in skillButtonDataByDisableSkillIdTag)
			{
				bool flag = false;
				bool flag2 = skillButtonData.IsEnable();
				if (flag2 == tagExist)
				{
					if (tagExist)
					{
						int? num = new int?(skillButtonData.GetSkillId());
						if (num != null)
						{
							int? num2 = num;
							int num3 = 0;
							HashSet<int> hashSet;
							if (!(num2.GetValueOrDefault() == num3 & num2 != null) && skillButtonData.GetDisableSkillIdTagIds().TryGetValue(tagId, out hashSet) && hashSet.Contains(num.Value))
							{
								skillButtonData.SetEnable(false, ESkillButtonDisableReason.DisableSkillIdTag);
								flag = true;
							}
						}
					}
					else
					{
						skillButtonData.RefreshIsEnable();
						flag = (skillButtonData.IsEnable() != flag2);
					}
					if (this.IsEnable && flag)
					{
						this.EnableChanged.Add(skillButtonData);
						this.EnableNextTick();
					}
				}
			}
		}

		// Token: 0x060348A4 RID: 215204 RVA: 0x00D2AC14 File Offset: 0x00D28E14
		private void OnNotOccupyTagChanged(int tagId, bool tagExist)
		{
			HashSet<SkillButtonData> hashSet = this.NotOccupyTagSkillButtonMapping.Get(tagId);
			if (hashSet == null)
			{
				return;
			}
			foreach (SkillButtonData skillButtonData in hashSet)
			{
				bool flag = skillButtonData.IsOccupy();
				if (flag == tagExist)
				{
					bool flag2;
					if (tagExist)
					{
						skillButtonData.SetNotOccupy();
						flag2 = true;
					}
					else
					{
						skillButtonData.RefreshIsOccupy();
						flag2 = (skillButtonData.IsOccupy() != flag);
					}
					if (flag2)
					{
						this.SkillIdChanged.Add(skillButtonData);
						this.EnableNextTick();
					}
				}
			}
		}

		// Token: 0x060348A5 RID: 215205 RVA: 0x00D2ACB4 File Offset: 0x00D28EB4
		private void OnSkillTagChanged(int tagId, bool tagExist)
		{
			HashSet<SkillButtonData> skillButtonDataBySkillIdTag = this.GetSkillButtonDataBySkillIdTag(tagId);
			if (skillButtonDataBySkillIdTag == null)
			{
				return;
			}
			foreach (SkillButtonData skillButtonData in skillButtonDataBySkillIdTag)
			{
				int? num = new int?(skillButtonData.GetSkillId());
				if (tagExist)
				{
					skillButtonData.RefreshSkillIdByTag(tagId);
				}
				else
				{
					skillButtonData.RefreshSkillId();
				}
				int? num2 = new int?(skillButtonData.GetSkillId());
				int? num3 = num;
				int? num4 = num2;
				if (!(num3.GetValueOrDefault() == num4.GetValueOrDefault() & num3 != null == (num4 != null)))
				{
					skillButtonData.RefreshSkillTexturePath();
					skillButtonData.RefreshIsEnable();
					if (this.IsEnable)
					{
						this.SkillIdChanged.Add(skillButtonData);
						this.EnableNextTick();
					}
				}
			}
		}

		// Token: 0x060348A6 RID: 215206 RVA: 0x00D2AD88 File Offset: 0x00D28F88
		private void OnSkillIconTagChanged(int tagId, bool tagExist)
		{
			HashSet<SkillButtonData> skillButtonDataBySkillIconTag = this.GetSkillButtonDataBySkillIconTag(tagId);
			if (skillButtonDataBySkillIconTag == null)
			{
				return;
			}
			foreach (SkillButtonData skillButtonData in skillButtonDataBySkillIconTag)
			{
				string skillTexturePath = skillButtonData.GetSkillTexturePath();
				if (tagExist)
				{
					skillButtonData.RefreshSkillTexturePathBySkillIconTag(tagId);
				}
				else
				{
					skillButtonData.RefreshSkillTexturePath();
				}
				if (this.IsEnable)
				{
					string skillTexturePath2 = skillButtonData.GetSkillTexturePath();
					if (skillTexturePath != skillTexturePath2)
					{
						this.SkillIconChanged.Add(skillButtonData);
						this.EnableNextTick();
					}
				}
			}
		}

		// Token: 0x060348A7 RID: 215207 RVA: 0x00D2AE24 File Offset: 0x00D29024
		private void OnDynamicEffectTagChanged(int tagId, bool tagExist)
		{
			HashSet<SkillButtonData> skillButtonDataByDynamicEffectTag = this.GetSkillButtonDataByDynamicEffectTag(tagId);
			if (skillButtonDataByDynamicEffectTag == null)
			{
				return;
			}
			foreach (SkillButtonData skillButtonData in skillButtonDataByDynamicEffectTag)
			{
				skillButtonData.RefreshDynamicEffect();
				if (this.IsEnable)
				{
					this.DynamicEffectChanged.Add(skillButtonData);
					this.EnableNextTick();
				}
			}
		}

		// Token: 0x060348A8 RID: 215208 RVA: 0x00D2AE98 File Offset: 0x00D29098
		private void OnCustomTagCountChanged(int count, int tagId, int exactTagId, int oldCount)
		{
			SkillButtonMapping<int> customHandleSkillButtonMapping = this.CustomHandleSkillButtonMapping;
			HashSet<SkillButtonData> hashSet = (customHandleSkillButtonMapping != null) ? customHandleSkillButtonMapping.Get(tagId) : null;
			if (hashSet == null)
			{
				return;
			}
			foreach (SkillButtonData skillButtonData in hashSet)
			{
				if (skillButtonData.CustomHandle != null)
				{
					skillButtonData.CustomHandle.RefreshByTagChanged();
					if (skillButtonData.CustomHandle.SkillCdModifyMark)
					{
						this.SkillCdChanged.Add(skillButtonData);
						this.EnableNextTick();
					}
					if (skillButtonData.CustomHandle.EnableModifyMark)
					{
						bool flag = skillButtonData.IsEnable();
						skillButtonData.RefreshIsEnable();
						if (flag != skillButtonData.IsEnable())
						{
							this.EnableChanged.Add(skillButtonData);
							this.EnableNextTick();
						}
					}
					skillButtonData.CustomHandle.ClearModifyMark();
				}
			}
		}

		// Token: 0x060348A9 RID: 215209 RVA: 0x00D2AF6C File Offset: 0x00D2916C
		private void OnAttributeChanged(EAttributeType attributeId, float newValue, float oldValue)
		{
			this.RefreshSkillButtonEnableByAttributeId(attributeId);
			HashSet<SkillButtonData> skillButtonDataByAttributeId = this.GetSkillButtonDataByAttributeId(attributeId);
			if (skillButtonDataByAttributeId == null)
			{
				return;
			}
			foreach (SkillButtonData item in skillButtonDataByAttributeId)
			{
				this.AttributeChanged.Add(item);
			}
			this.EnableNextTick();
		}

		// Token: 0x060348AA RID: 215210 RVA: 0x00D2AFDC File Offset: 0x00D291DC
		public void RefreshSkillButtonEnableByAttributeId(EAttributeType attributeId)
		{
			HashSet<SkillButtonData> skillButtonDataByAttributeId = this.GetSkillButtonDataByAttributeId(attributeId);
			if (skillButtonDataByAttributeId == null)
			{
				return;
			}
			foreach (SkillButtonData skillButtonData in skillButtonDataByAttributeId)
			{
				bool flag = skillButtonData.IsEnable();
				skillButtonData.RefreshIsEnable();
				bool flag2 = skillButtonData.IsEnable();
				if (flag != flag2)
				{
					this.EnableChanged.Add(skillButtonData);
					this.EnableNextTick();
				}
			}
		}

		// Token: 0x060348AB RID: 215211 RVA: 0x00D2B058 File Offset: 0x00D29258
		public void RefreshEnableByInputEvent(EInputAction inputAction, bool enable)
		{
			foreach (SkillButtonData skillButtonData in this.SkillButtonDataMap.Values)
			{
				if (!(skillButtonData.GetActionType() != inputAction))
				{
					bool flag = skillButtonData.IsEnable();
					skillButtonData.RefreshIsEnable();
					if (this.IsEnable)
					{
						bool flag2 = skillButtonData.IsEnable();
						if (flag != flag2)
						{
							this.EnableChanged.Add(skillButtonData);
							this.EnableNextTick();
						}
					}
				}
			}
		}

		// Token: 0x060348AC RID: 215212 RVA: 0x00D2B0EC File Offset: 0x00D292EC
		public void RefreshVisibleByInputEvent(EInputAction inputAction, bool visible)
		{
			foreach (SkillButtonData skillButtonData in this.SkillButtonDataMap.Values)
			{
				if (!(skillButtonData.GetActionType() != inputAction))
				{
					bool flag = skillButtonData.IsVisible();
					if (!visible)
					{
						skillButtonData.SetInvisible();
					}
					else
					{
						skillButtonData.RefreshIsVisible(true);
					}
					if (this.IsEnable)
					{
						bool flag2 = skillButtonData.IsVisible();
						if (flag != flag2)
						{
							this.VisibleChanged.Add(skillButtonData);
							this.EnableNextTick();
						}
					}
				}
			}
		}

		// Token: 0x060348AD RID: 215213 RVA: 0x00D2B18C File Offset: 0x00D2938C
		public void RefreshEnableByButtonType(ESkillButtonType buttonType)
		{
			SkillButtonData skillButtonDataByButton = this.GetSkillButtonDataByButton(buttonType);
			if (skillButtonDataByButton == null)
			{
				return;
			}
			bool flag = skillButtonDataByButton.IsEnable();
			skillButtonDataByButton.RefreshIsEnable();
			if (!this.IsEnable)
			{
				return;
			}
			bool flag2 = skillButtonDataByButton.IsEnable();
			if (flag != flag2)
			{
				this.EnableChanged.Add(skillButtonDataByButton);
				this.EnableNextTick();
			}
		}

		// Token: 0x060348AE RID: 215214 RVA: 0x00D2B1DC File Offset: 0x00D293DC
		public void RefreshVisibleByButtonType(ESkillButtonType buttonType)
		{
			SkillButtonData skillButtonDataByButton = this.GetSkillButtonDataByButton(buttonType);
			if (skillButtonDataByButton == null)
			{
				return;
			}
			bool flag = skillButtonDataByButton.IsVisible();
			skillButtonDataByButton.RefreshIsVisible(true);
			if (!this.IsEnable)
			{
				return;
			}
			bool flag2 = skillButtonDataByButton.IsVisible();
			if (flag != flag2)
			{
				this.VisibleChanged.Add(skillButtonDataByButton);
				this.EnableNextTick();
			}
		}

		// Token: 0x060348AF RID: 215215 RVA: 0x00D2B22C File Offset: 0x00D2942C
		public void RefreshSkillTexturePath(ESkillButtonType buttonType)
		{
			SkillButtonData skillButtonDataByButton = this.GetSkillButtonDataByButton(buttonType);
			if (skillButtonDataByButton == null)
			{
				return;
			}
			string skillTexturePath = skillButtonDataByButton.GetSkillTexturePath();
			skillButtonDataByButton.RefreshSkillTexturePath();
			if (!this.IsEnable)
			{
				return;
			}
			if (skillTexturePath != skillButtonDataByButton.GetSkillTexturePath())
			{
				this.SkillIconChanged.Add(skillButtonDataByButton);
				this.EnableNextTick();
			}
		}

		// Token: 0x060348B0 RID: 215216 RVA: 0x00D2B27C File Offset: 0x00D2947C
		public void RefreshSkillCd(int skillId)
		{
			foreach (SkillButtonData skillButtonData in this.SkillButtonDataMap.Values)
			{
				if (skillButtonData.GetSkillId() == skillId)
				{
					skillButtonData.RefreshIsEnable();
					if (this.IsEnable && skillButtonData.IsOccupy())
					{
						this.SkillCdChanged.Add(skillButtonData);
						this.EnableNextTick();
					}
				}
			}
		}

		// Token: 0x060348B1 RID: 215217 RVA: 0x00D2B300 File Offset: 0x00D29500
		private void ClearAllEvent()
		{
			EntityHandle entityHandle = this.EntityHandle;
			if (entityHandle == null || !entityHandle.Valid)
			{
				return;
			}
			this.ClearNextTick();
			this.ClearAllTagSignificantChangedWithTagTasks();
			this.ClearAllAttributeChanged();
		}

		// Token: 0x060348B2 RID: 215218 RVA: 0x00D2B32C File Offset: 0x00D2952C
		private void ClearAllTagSignificantChangedWithTagTasks()
		{
			foreach (ITagTask tagTask in this.TagSignificantChangedWithTagTasks)
			{
				if (tagTask != null)
				{
					tagTask.EndTask();
				}
			}
			this.TagSignificantChangedWithTagTasks.Clear();
		}

		// Token: 0x060348B3 RID: 215219 RVA: 0x00D2B390 File Offset: 0x00D29590
		private void ClearAllAttributeChanged()
		{
			foreach (KeyValuePair<EAttributeType, Action<EAttributeType, float, float>> keyValuePair in this.AttributeChangedCallbackMap)
			{
				BaseAttributeComponent attributeComponent = this.AttributeComponent;
				if (attributeComponent != null)
				{
					attributeComponent.RemoveListener(keyValuePair.Key, keyValuePair.Value);
				}
			}
		}

		// Token: 0x060348B4 RID: 215220 RVA: 0x00D2B3FC File Offset: 0x00D295FC
		public SkillButtonData GetSkillButtonDataByButton(ESkillButtonType buttonType)
		{
			SkillButtonData result;
			if (!this.SkillButtonDataMap.TryGetValue(buttonType, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x060348B5 RID: 215221 RVA: 0x00D2B41C File Offset: 0x00D2961C
		public BehaviorButtonData GetBehaviorButtonDataByButton(int buttonType)
		{
			return null;
		}

		// Token: 0x060348B6 RID: 215222 RVA: 0x00D2B420 File Offset: 0x00D29620
		public SkillButtonData GetSkillButtonDataBySkillId(int skillId)
		{
			foreach (SkillButtonData skillButtonData in this.SkillButtonDataMap.Values)
			{
				if (skillButtonData.GetSkillId() == skillId)
				{
					return skillButtonData;
				}
			}
			return null;
		}

		// Token: 0x060348B7 RID: 215223 RVA: 0x00D2B484 File Offset: 0x00D29684
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public HashSet<SkillButtonData> GetSkillButtonDataByAttributeId(EAttributeType attributeId)
		{
			return this.AttributeIdSkillButtonMapping.Get(attributeId);
		}

		// Token: 0x060348B8 RID: 215224 RVA: 0x00D2B492 File Offset: 0x00D29692
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public HashSet<SkillButtonData> GetSkillButtonDataByDisableTag(int tagId)
		{
			return this.DisableTagSkillButtonMapping.Get(tagId);
		}

		// Token: 0x060348B9 RID: 215225 RVA: 0x00D2B4A0 File Offset: 0x00D296A0
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public HashSet<SkillButtonData> GetSkillButtonDataByDisableSkillIdTag(int tagId)
		{
			return this.DisableSkillIdTagSkillButtonMapping.Get(tagId);
		}

		// Token: 0x060348BA RID: 215226 RVA: 0x00D2B4AE File Offset: 0x00D296AE
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public HashSet<SkillButtonData> GetSkillButtonDataBySkillIdTag(int tagId)
		{
			return this.SkillIdTagSkillButtonMapping.Get(tagId);
		}

		// Token: 0x060348BB RID: 215227 RVA: 0x00D2B4BC File Offset: 0x00D296BC
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public HashSet<SkillButtonData> GetSkillButtonDataBySkillIconTag(int tag)
		{
			return this.SkillIconTagSkillButtonMapping.Get(tag);
		}

		// Token: 0x060348BC RID: 215228 RVA: 0x00D2B4CA File Offset: 0x00D296CA
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public HashSet<SkillButtonData> GetSkillButtonDataByDynamicEffectTag(int tag)
		{
			return this.DynamicEffectTagSkillButtonMapping.Get(tag);
		}

		// Token: 0x0401E454 RID: 123988
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly Stat NextTickStat = Stat.Create("SkillButtonEntityDataNextTick", "", "");

		// Token: 0x0401E455 RID: 123989
		public bool IsEnable;

		// Token: 0x0401E456 RID: 123990
		public EntityHandle EntityHandle;

		// Token: 0x0401E457 RID: 123991
		public int PbDataId;

		// Token: 0x0401E458 RID: 123992
		public BaseAttributeComponent AttributeComponent;

		// Token: 0x0401E459 RID: 123993
		public BaseTagComponent GameplayTagComponent;

		// Token: 0x0401E45A RID: 123994
		public CharacterSkillComponent SkillComponent;

		// Token: 0x0401E45B RID: 123995
		public IReadOnlyList<SkillFollowerButton> SkillButtonConfigList;

		// Token: 0x0401E45C RID: 123996
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Dictionary<ESkillButtonType, SkillButtonData> SkillButtonDataMap = new Dictionary<ESkillButtonType, SkillButtonData>();

		// Token: 0x0401E45D RID: 123997
		public SkillButtonMapping<EAttributeType> AttributeIdSkillButtonMapping = new SkillButtonMapping<EAttributeType>();

		// Token: 0x0401E45E RID: 123998
		public SkillButtonMapping<int> AttributeIdTagSkillButtonMapping = new SkillButtonMapping<int>();

		// Token: 0x0401E45F RID: 123999
		public SkillButtonMapping<int> DisableTagSkillButtonMapping = new SkillButtonMapping<int>();

		// Token: 0x0401E460 RID: 124000
		public SkillButtonMapping<int> DisableSkillIdTagSkillButtonMapping = new SkillButtonMapping<int>();

		// Token: 0x0401E461 RID: 124001
		public SkillButtonMapping<int> CustomHandleSkillButtonMapping = new SkillButtonMapping<int>();

		// Token: 0x0401E462 RID: 124002
		public SkillButtonMapping<int> NotOccupyTagSkillButtonMapping = new SkillButtonMapping<int>();

		// Token: 0x0401E463 RID: 124003
		public SkillButtonMapping<int> DynamicEffectTagSkillButtonMapping = new SkillButtonMapping<int>();

		// Token: 0x0401E464 RID: 124004
		public SkillButtonMapping<int> SkillIconTagSkillButtonMapping = new SkillButtonMapping<int>();

		// Token: 0x0401E465 RID: 124005
		public SkillButtonMapping<int> SkillIdTagSkillButtonMapping = new SkillButtonMapping<int>();

		// Token: 0x0401E466 RID: 124006
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private HashSet<ITagTask> TagSignificantChangedWithTagTasks = new HashSet<ITagTask>();

		// Token: 0x0401E467 RID: 124007
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<EAttributeType, Action<EAttributeType, float, float>> AttributeChangedCallbackMap = new Dictionary<EAttributeType, Action<EAttributeType, float, float>>();

		// Token: 0x0401E468 RID: 124008
		private TimerHandle NextTickTimerId;

		// Token: 0x0401E469 RID: 124009
		[Nullable(1)]
		private readonly HashSet<SkillButtonData> EnableChanged = new HashSet<SkillButtonData>();

		// Token: 0x0401E46A RID: 124010
		[Nullable(1)]
		private readonly HashSet<SkillButtonData> VisibleChanged = new HashSet<SkillButtonData>();

		// Token: 0x0401E46B RID: 124011
		[Nullable(1)]
		private readonly HashSet<SkillButtonData> SkillIdChanged = new HashSet<SkillButtonData>();

		// Token: 0x0401E46C RID: 124012
		[Nullable(1)]
		private readonly HashSet<SkillButtonData> SkillIconChanged = new HashSet<SkillButtonData>();

		// Token: 0x0401E46D RID: 124013
		[Nullable(1)]
		private readonly HashSet<SkillButtonData> DynamicEffectChanged = new HashSet<SkillButtonData>();

		// Token: 0x0401E46E RID: 124014
		[Nullable(1)]
		private readonly HashSet<SkillButtonData> SkillCdChanged = new HashSet<SkillButtonData>();

		// Token: 0x0401E46F RID: 124015
		[Nullable(1)]
		private readonly HashSet<SkillButtonData> AttributeChanged = new HashSet<SkillButtonData>();

		// Token: 0x0401E470 RID: 124016
		private bool SkillButtonDataRefresh;

		// Token: 0x0401E471 RID: 124017
		private ESkillButtonRefreshReason SkillButtonDataRefreshReason = ESkillButtonRefreshReason.None;
	}
}
