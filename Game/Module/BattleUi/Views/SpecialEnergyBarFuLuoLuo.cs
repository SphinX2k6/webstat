using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Pawn.Component;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060B9 RID: 24761
	[NullableContext(1)]
	[Nullable(0)]
	public class SpecialEnergyBarFuLuoLuo : SpecialEnergyBarBase
	{
		// Token: 0x0603E867 RID: 256103 RVA: 0x00FFCB34 File Offset: 0x00FFAD34
		protected unsafe override void OnRegisterComponent()
		{
			int num = 19;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E868 RID: 256104 RVA: 0x00FFCDD9 File Offset: 0x00FFAFD9
		protected override void OnInitData()
		{
			this.BurstConfig = ModelBase<BattleUiModel>.Instance.SpecialEnergyBarData.GetSpecialEnergyBarInfo(160801);
		}

		// Token: 0x0603E869 RID: 256105 RVA: 0x00FFCDF8 File Offset: 0x00FFAFF8
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarFuLuoLuo.<OnBeforeStartAsync>d__26 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarFuLuoLuo.<OnBeforeStartAsync>d__26>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E86A RID: 256106 RVA: 0x00FFCE3C File Offset: 0x00FFB03C
		protected UniTask InitBurstKeyItem(UUIItem keyItemContainer)
		{
			SpecialEnergyBarFuLuoLuo.<InitBurstKeyItem>d__27 <InitBurstKeyItem>d__;
			<InitBurstKeyItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBurstKeyItem>d__.<>4__this = this;
			<InitBurstKeyItem>d__.keyItemContainer = keyItemContainer;
			<InitBurstKeyItem>d__.<>1__state = -1;
			<InitBurstKeyItem>d__.<>t__builder.Start<SpecialEnergyBarFuLuoLuo.<InitBurstKeyItem>d__27>(ref <InitBurstKeyItem>d__);
			return <InitBurstKeyItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603E86B RID: 256107 RVA: 0x00FFCE88 File Offset: 0x00FFB088
		private UniTask InitNoteItems()
		{
			SpecialEnergyBarFuLuoLuo.<InitNoteItems>d__28 <InitNoteItems>d__;
			<InitNoteItems>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitNoteItems>d__.<>4__this = this;
			<InitNoteItems>d__.<>1__state = -1;
			<InitNoteItems>d__.<>t__builder.Start<SpecialEnergyBarFuLuoLuo.<InitNoteItems>d__28>(ref <InitNoteItems>d__);
			return <InitNoteItems>d__.<>t__builder.Task;
		}

		// Token: 0x0603E86C RID: 256108 RVA: 0x00FFCECC File Offset: 0x00FFB0CC
		protected override void OnStart()
		{
			base.OnStart();
			BattleUiRoleData roleData = this.RoleData;
			Entity entity;
			if (roleData == null)
			{
				entity = null;
			}
			else
			{
				EntityHandle entityHandle = roleData.EntityHandle;
				entity = ((entityHandle != null) ? entityHandle.Entity : null);
			}
			this.Entity = entity;
			SpecialEnergyBarInfo config = this.Config;
			if (!string.IsNullOrEmpty((config != null) ? config.EffectColor : null))
			{
				FColor item = FColor.FromHex(this.Config.EffectColor);
				this.ColorList.Add(item);
			}
			SpecialEnergyBarInfo config2 = this.Config;
			if (((config2 != null) ? config2.OtherEffectColorList : null) != null)
			{
				foreach (string hexStr in this.Config.OtherEffectColorList)
				{
					FColor item2 = FColor.FromHex(hexStr);
					this.ColorList.Add(item2);
				}
			}
			base.InitTweenAnim(13);
			base.InitTweenAnim(14);
			base.InitTweenAnim(15);
			base.InitTweenAnim(16);
			base.InitTweenAnim(17);
			for (int i = 0; i < 6; i++)
			{
				UUIItem item3 = base.GetItem(7 + i);
				this.PosItemList.Add(item3);
				UUIItem item4 = base.GetItem(1 + i);
				this.SlotItemList.Add(item4);
			}
			this.RefreshBar(true);
			this.RefreshTimeScale();
		}

		// Token: 0x0603E86D RID: 256109 RVA: 0x00FFD014 File Offset: 0x00FFB214
		protected override void AddEvents()
		{
			base.AddEvents();
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarFuLuoLuo.LockTag, new BaseTagComponent.TTagSwitchedCallback(this.OnLockTagChange));
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarFuLuoLuo.BurstTag, new BaseTagComponent.TTagSwitchedCallback(this.OnBurstTagChange));
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarFuLuoLuo.DisableTag, new BaseTagComponent.TTagSwitchedCallback(this.OnDisableTagChange));
			if (this.Entity != null)
			{
				Singleton<EventSystem>.Instance.AddWithTarget<float, ETimeScaleSourceType>(this.Entity, EEventName.CharBeHitTimeScale, new Action<float, ETimeScaleSourceType>(this.CharBeHitTimeScale));
			}
			Singleton<EventSystem>.Instance.Add(EEventName.TriggerUiTimeDilation, new Action(this.OnTimeScaleChange));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.FuLuoLuoAddDuplicatedEnergy, new Action<int>(this.OnAddDuplicatedEnergy));
		}

		// Token: 0x0603E86E RID: 256110 RVA: 0x00FFD0C8 File Offset: 0x00FFB2C8
		protected override void RemoveEvents()
		{
			base.RemoveEvents();
			if (this.Entity != null)
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget<float, ETimeScaleSourceType>(this.Entity, EEventName.CharBeHitTimeScale, new Action<float, ETimeScaleSourceType>(this.CharBeHitTimeScale));
			}
			Singleton<EventSystem>.Instance.Remove(EEventName.TriggerUiTimeDilation, new Action(this.OnTimeScaleChange));
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.FuLuoLuoAddDuplicatedEnergy, new Action<int>(this.OnAddDuplicatedEnergy));
		}

		// Token: 0x0603E86F RID: 256111 RVA: 0x00FFD134 File Offset: 0x00FFB334
		protected override void OnBeforeDestroy()
		{
			if (this.BurstKeyItem != null)
			{
				SpecialEnergyBarKeyItem burstKeyItem = this.BurstKeyItem;
				if (burstKeyItem != null)
				{
					burstKeyItem.Destroy(null);
				}
				this.BurstKeyItem = null;
			}
			base.OnBeforeDestroy();
		}

		// Token: 0x0603E870 RID: 256112 RVA: 0x00FFD15D File Offset: 0x00FFB35D
		private void OnLockTagChange(int tagId, bool tagExist)
		{
			this.SetLockState(tagExist, false);
		}

		// Token: 0x0603E871 RID: 256113 RVA: 0x00FFD167 File Offset: 0x00FFB367
		private void OnBurstTagChange(int tagId, bool tagExist)
		{
			this.SetBurstState(tagExist, false);
		}

		// Token: 0x0603E872 RID: 256114 RVA: 0x00FFD171 File Offset: 0x00FFB371
		private void OnDisableTagChange(int tagId, bool tagExist)
		{
			this.SetKeyDisableState(tagExist);
		}

		// Token: 0x0603E873 RID: 256115 RVA: 0x00FFD17A File Offset: 0x00FFB37A
		private void CharBeHitTimeScale(float _1, ETimeScaleSourceType _2)
		{
			this.OnTimeScaleChange();
		}

		// Token: 0x0603E874 RID: 256116 RVA: 0x00FFD182 File Offset: 0x00FFB382
		private void OnTimeScaleChange()
		{
			if (this.IsPerforming)
			{
				this.RefreshTimeScale();
			}
		}

		// Token: 0x0603E875 RID: 256117 RVA: 0x00FFD194 File Offset: 0x00FFB394
		private void RefreshTimeScale()
		{
			float num = 1f;
			if (this.BuffComponent != null)
			{
				num = this.BuffComponent.GetTimeScale();
			}
			if (this.TimeScale == num)
			{
				return;
			}
			this.TimeScale = num;
			if (this.PerformTimer != null && TimerSystem.Instance.Has(this.PerformTimer))
			{
				if (this.TimeScale <= 0f)
				{
					if (!TimerSystem.Instance.IsPause(this.PerformTimer))
					{
						TimerSystem.Instance.Pause(this.PerformTimer, null);
					}
				}
				else
				{
					if (TimerSystem.Instance.IsPause(this.PerformTimer))
					{
						TimerSystem.Instance.Resume(this.PerformTimer);
					}
					TimerSystem.Instance.ChangeDilation(this.PerformTimer, this.TimeScale, null);
				}
			}
			float timeScale = num / Singleton<Time>.Instance.InverseSelfCenteredTimeDilation;
			base.SetTweenTimeScale(17, timeScale);
		}

		// Token: 0x0603E876 RID: 256118 RVA: 0x00FFD270 File Offset: 0x00FFB470
		private void OnAddDuplicatedEnergy(int entityId)
		{
			if (this.SpecialEnergyTypeList.Count < 6)
			{
				return;
			}
			int num = -1;
			int num2 = 0;
			for (int i = 0; i < 6; i++)
			{
				num2 = this.SpecialEnergyTypeList[i];
				if (num2 != 3)
				{
					num = i;
					break;
				}
			}
			if (num2 == 0)
			{
				return;
			}
			for (int j = num + 1; j < 6; j++)
			{
				if (this.SpecialEnergyTypeList[j] != num2)
				{
					return;
				}
			}
			this.PlayAniNoteOffset(num, 6);
		}

		// Token: 0x0603E877 RID: 256119 RVA: 0x00FFD2DB File Offset: 0x00FFB4DB
		protected override void OnAttributeChanged()
		{
			this.RefreshBar(false);
		}

		// Token: 0x0603E878 RID: 256120 RVA: 0x00FFD2E4 File Offset: 0x00FFB4E4
		protected override void OnMaxAttributeChanged()
		{
		}

		// Token: 0x0603E879 RID: 256121 RVA: 0x00FFD2E8 File Offset: 0x00FFB4E8
		private void RefreshBar(bool isStart = false)
		{
			if (!isStart)
			{
				List<int> lastSpecialEnergyTypeList = this.LastSpecialEnergyTypeList;
				this.LastSpecialEnergyTypeList = this.SpecialEnergyTypeList;
				this.SpecialEnergyTypeList = lastSpecialEnergyTypeList;
			}
			this.SpecialEnergyTypeList.Clear();
			int num = (int)this.AttributeComponent.GetCurrentValue(this.AttributeId);
			for (int i = 0; i < 6; i++)
			{
				int num2 = (6 - i - 1) * 2;
				int num3 = (num & 3 << num2) >> num2;
				if (num3 > 0)
				{
					this.SpecialEnergyTypeList.Add(num3);
				}
			}
			if (isStart)
			{
				for (int j = 0; j < 6; j++)
				{
					SpecialEnergyBarFuLuoLuoNoteItem specialEnergyBarFuLuoLuoNoteItem = this.NoteItemList[j];
					int valueOrDefault = this.SpecialEnergyTypeList.GetValueOrDefault(j, 0);
					specialEnergyBarFuLuoLuoNoteItem.SetEnergyType(valueOrDefault);
					specialEnergyBarFuLuoLuoNoteItem.SetParent(this.SlotItemList[j]);
				}
				this.NoteItemList[6].SetEnergyType(0);
				BaseTagComponent tagComponent = this.TagComponent;
				this.SetLockState(tagComponent != null && tagComponent.HasTag(SpecialEnergyBarFuLuoLuo.LockTag), isStart);
				BaseTagComponent tagComponent2 = this.TagComponent;
				this.SetBurstState(tagComponent2 != null && tagComponent2.HasTag(SpecialEnergyBarFuLuoLuo.BurstTag), isStart);
				BaseTagComponent tagComponent3 = this.TagComponent;
				this.SetKeyDisableState(tagComponent3 != null && tagComponent3.HasTag(SpecialEnergyBarFuLuoLuo.DisableTag));
			}
			else
			{
				int count = this.LastSpecialEnergyTypeList.Count;
				int count2 = this.SpecialEnergyTypeList.Count;
				if (count2 > count)
				{
					this.RefreshAllNoteItemEnergyType();
				}
				else if (count2 == count)
				{
					int num4 = -1;
					for (int k = 0; k < count2; k++)
					{
						if (this.LastSpecialEnergyTypeList[k] != 3)
						{
							num4 = k;
							break;
						}
					}
					if (num4 >= 0)
					{
						this.PlayAniNoteOffset(num4, count2);
					}
				}
				else if (!this.BurstState)
				{
					this.RefreshAllNoteItemEnergyType();
				}
			}
			this.RefreshKeyItem(isStart);
			this.RefreshKeyEnable(isStart);
		}

		// Token: 0x0603E87A RID: 256122 RVA: 0x00FFD4A4 File Offset: 0x00FFB6A4
		private void PlayAniNoteOffset(int startIndex, int specialEnergyTypeNum)
		{
			SpecialEnergyBarFuLuoLuoNoteItem specialEnergyBarFuLuoLuoNoteItem = this.NoteItemList[startIndex];
			this.NoteItemList.RemoveAt(startIndex);
			this.NoteItemList.Add(specialEnergyBarFuLuoLuoNoteItem);
			base.StopTweenAnim(13);
			this.PosItemList[5].SetAlpha(1f);
			specialEnergyBarFuLuoLuoNoteItem.SetParent(this.SlotItemList[startIndex]);
			for (int i = 0; i < startIndex; i++)
			{
				this.NoteItemList[i].SetParent(this.SlotItemList[i]);
			}
			for (int j = startIndex; j < specialEnergyTypeNum; j++)
			{
				this.NoteItemList[j].SetParent(this.PosItemList[j]);
			}
			this.RefreshAllNoteItemEnergyType();
			base.PlayTweenAnim(13);
		}

		// Token: 0x0603E87B RID: 256123 RVA: 0x00FFD568 File Offset: 0x00FFB768
		private void RefreshKeyItem(bool isStart)
		{
			if (this.BurstState)
			{
				SpecialEnergyBarKeyItem keyItem = this.KeyItem;
				if (keyItem != null)
				{
					keyItem.SetUiActive(false);
				}
				SpecialEnergyBarKeyItem burstKeyItem = this.BurstKeyItem;
				if (burstKeyItem == null)
				{
					return;
				}
				burstKeyItem.SetUiActive(false);
				return;
			}
			else if (this.LockState)
			{
				SpecialEnergyBarKeyItem keyItem2 = this.KeyItem;
				if (keyItem2 != null)
				{
					keyItem2.SetUiActive(false);
				}
				SpecialEnergyBarKeyItem burstKeyItem2 = this.BurstKeyItem;
				if (burstKeyItem2 != null)
				{
					burstKeyItem2.SetUiActive(true);
				}
				SpecialEnergyBarKeyItem burstKeyItem3 = this.BurstKeyItem;
				if (burstKeyItem3 == null)
				{
					return;
				}
				burstKeyItem3.RefreshKeyEnable(true, isStart);
				return;
			}
			else
			{
				SpecialEnergyBarKeyItem keyItem3 = this.KeyItem;
				if (keyItem3 != null)
				{
					keyItem3.SetUiActive(true);
				}
				SpecialEnergyBarKeyItem burstKeyItem4 = this.BurstKeyItem;
				if (burstKeyItem4 == null)
				{
					return;
				}
				burstKeyItem4.SetUiActive(false);
				return;
			}
		}

		// Token: 0x0603E87C RID: 256124 RVA: 0x00FFD604 File Offset: 0x00FFB804
		private void RefreshKeyEnable(bool isStart)
		{
			bool keyEnable = this.GetKeyEnable();
			SpecialEnergyBarKeyItem keyItem = this.KeyItem;
			if (keyItem == null)
			{
				return;
			}
			keyItem.RefreshKeyEnable(keyEnable, isStart);
		}

		// Token: 0x0603E87D RID: 256125 RVA: 0x00FFD62A File Offset: 0x00FFB82A
		protected override bool GetKeyEnable()
		{
			return this.SpecialEnergyTypeList.Count >= 6 && !this.KeyDisableState;
		}

		// Token: 0x0603E87E RID: 256126 RVA: 0x00FFD647 File Offset: 0x00FFB847
		private void SetKeyDisableState(bool state)
		{
			if (this.KeyDisableState == state)
			{
				return;
			}
			this.KeyDisableState = state;
			this.RefreshKeyEnable(false);
		}

		// Token: 0x0603E87F RID: 256127 RVA: 0x00FFD664 File Offset: 0x00FFB864
		private void RefreshAllNoteItemEnergyType()
		{
			for (int i = 0; i < this.NoteItemList.Count; i++)
			{
				SpecialEnergyBarFuLuoLuoNoteItem specialEnergyBarFuLuoLuoNoteItem = this.NoteItemList[i];
				int valueOrDefault = this.SpecialEnergyTypeList.GetValueOrDefault(i, 0);
				specialEnergyBarFuLuoLuoNoteItem.SetEnergyType(valueOrDefault);
			}
		}

		// Token: 0x0603E880 RID: 256128 RVA: 0x00FFD6A8 File Offset: 0x00FFB8A8
		private void SetLockState(bool state, bool isStart = false)
		{
			if (this.LockState == state)
			{
				return;
			}
			this.LockState = state;
			if (state)
			{
				base.StopTweenAnim(16);
				base.PlayTweenAnim(15);
			}
			else
			{
				base.StopTweenAnim(15);
				base.PlayTweenAnim(16);
			}
			foreach (SpecialEnergyBarFuLuoLuoNoteItem specialEnergyBarFuLuoLuoNoteItem in this.NoteItemList)
			{
				specialEnergyBarFuLuoLuoNoteItem.SetLockState(state);
			}
			if (!isStart)
			{
				this.RefreshKeyItem(isStart);
			}
		}

		// Token: 0x0603E881 RID: 256129 RVA: 0x00FFD73C File Offset: 0x00FFB93C
		private void SetBurstState(bool state, bool isStart = false)
		{
			if (this.BurstState == state)
			{
				return;
			}
			this.BurstState = state;
			if (state)
			{
				this.StartBurstAnim();
			}
			else
			{
				this.StopBurstAnim();
			}
			if (!isStart)
			{
				this.RefreshKeyItem(isStart);
			}
		}

		// Token: 0x0603E882 RID: 256130 RVA: 0x00FFD76C File Offset: 0x00FFB96C
		private void StartBurstAnim()
		{
			if (this.IsPerforming)
			{
				return;
			}
			this.IsPerforming = true;
			this.NoteCount = 0;
			for (int i = 0; i < 6; i++)
			{
				this.NoteItemList[i].SetParent(this.SlotItemList[i]);
			}
			base.StopTweenAnim(16);
			base.PlayTweenAnim(17);
			this.RefreshTimeScale();
			this.PerformTimer = TimerSystem.Instance.Delay(new TTimerAction(this.OnFirstNoteTimer), 1250f, null, null, true, 1f);
			if (this.PerformTimer != null && this.TimeScale != 1f)
			{
				if (this.TimeScale <= 0f)
				{
					TimerSystem.Instance.Pause(this.PerformTimer, null);
					return;
				}
				TimerSystem.Instance.ChangeDilation(this.PerformTimer, this.TimeScale, null);
			}
		}

		// Token: 0x0603E883 RID: 256131 RVA: 0x00FFD848 File Offset: 0x00FFBA48
		private void StopBurstAnim()
		{
			this.IsPerforming = false;
			base.StopTweenAnim(17);
			base.PlayTweenAnim(16);
			this.RefreshAllNoteItemEnergyType();
			foreach (UUIItem uuiitem in this.SlotItemList)
			{
				uuiitem.SetAlpha(1f);
			}
			for (int i = 0; i < 6; i++)
			{
				SpecialEnergyBarFuLuoLuoNoteItem specialEnergyBarFuLuoLuoNoteItem = this.NoteItemList[i];
				specialEnergyBarFuLuoLuoNoteItem.SetParent(this.SlotItemList[i]);
				specialEnergyBarFuLuoLuoNoteItem.SetPerformState(false);
			}
			this.NoteItemList[6].SetPerformState(false);
			this.RemovePerformTimer();
			this.RefreshTimeScale();
		}

		// Token: 0x0603E884 RID: 256132 RVA: 0x00FFD908 File Offset: 0x00FFBB08
		private void OnFirstNoteTimer(float _)
		{
			this.NextNotePerform();
			this.NoteCount++;
			this.PerformTimer = TimerSystem.Instance.Loop(new TTimerAction(this.OnTimer), 4000f, 5, this.TimeScale, null, null, true);
		}

		// Token: 0x0603E885 RID: 256133 RVA: 0x00FFD954 File Offset: 0x00FFBB54
		private void OnTimer(float _)
		{
			this.NextNotePerform();
			this.NoteCount++;
			if (this.NoteCount < 6)
			{
				return;
			}
			this.RemovePerformTimer();
		}

		// Token: 0x0603E886 RID: 256134 RVA: 0x00FFD97C File Offset: 0x00FFBB7C
		private void NextNotePerform()
		{
			SpecialEnergyBarFuLuoLuoNoteItem specialEnergyBarFuLuoLuoNoteItem = this.NoteItemList.Shift<SpecialEnergyBarFuLuoLuoNoteItem>();
			this.NoteItemList.Add(specialEnergyBarFuLuoLuoNoteItem);
			specialEnergyBarFuLuoLuoNoteItem.SetPerformState(true);
		}

		// Token: 0x0603E887 RID: 256135 RVA: 0x00FFD9A8 File Offset: 0x00FFBBA8
		private void RemovePerformTimer()
		{
			if (this.PerformTimer != null && TimerSystem.Instance.Has(this.PerformTimer))
			{
				TimerSystem.Instance.Remove(this.PerformTimer);
				this.PerformTimer = null;
			}
		}

		// Token: 0x040230C6 RID: 143558
		private const int SPECIAL_ENERGY_COUNT = 6;

		// Token: 0x040230C7 RID: 143559
		[StaticVariableRuleIgnore]
		private static readonly int LockTag = GameplayTagDefine.EGameplayTagId["角色.R2T1FuluoluoMd10011.状态标识.乐谱锁定"];

		// Token: 0x040230C8 RID: 143560
		[StaticVariableRuleIgnore]
		private static readonly int BurstTag = GameplayTagDefine.EGameplayTagId["角色.R2T1FuluoluoMd10011.状态标识.大招状态"];

		// Token: 0x040230C9 RID: 143561
		[StaticVariableRuleIgnore]
		private static readonly int DisableTag = GameplayTagDefine.EGameplayTagId["角色.R2T1FuluoluoMd10011.状态标识.强化重击CD"];

		// Token: 0x040230CA RID: 143562
		private const int FIRST_NOTE_TIME = 1250;

		// Token: 0x040230CB RID: 143563
		private const int NOTE_INTERVAL_TIME = 4000;

		// Token: 0x040230CC RID: 143564
		private const int BURST_CONFIG_ID = 160801;

		// Token: 0x040230CD RID: 143565
		[Nullable(2)]
		private Entity Entity;

		// Token: 0x040230CE RID: 143566
		[Nullable(2)]
		private SpecialEnergyBarInfo BurstConfig;

		// Token: 0x040230CF RID: 143567
		[Nullable(2)]
		private SpecialEnergyBarKeyItem BurstKeyItem;

		// Token: 0x040230D0 RID: 143568
		private List<int> SpecialEnergyTypeList = new List<int>();

		// Token: 0x040230D1 RID: 143569
		private List<int> LastSpecialEnergyTypeList = new List<int>();

		// Token: 0x040230D2 RID: 143570
		private readonly List<FColor> ColorList = new List<FColor>();

		// Token: 0x040230D3 RID: 143571
		private readonly List<SpecialEnergyBarFuLuoLuoNoteItem> NoteItemList = new List<SpecialEnergyBarFuLuoLuoNoteItem>();

		// Token: 0x040230D4 RID: 143572
		private readonly List<UUIItem> SlotItemList = new List<UUIItem>();

		// Token: 0x040230D5 RID: 143573
		private readonly List<UUIItem> PosItemList = new List<UUIItem>();

		// Token: 0x040230D6 RID: 143574
		private bool LockState;

		// Token: 0x040230D7 RID: 143575
		private bool BurstState;

		// Token: 0x040230D8 RID: 143576
		private bool KeyDisableState;

		// Token: 0x040230D9 RID: 143577
		private bool IsPerforming;

		// Token: 0x040230DA RID: 143578
		[Nullable(2)]
		private TimerHandle PerformTimer;

		// Token: 0x040230DB RID: 143579
		private int NoteCount;

		// Token: 0x040230DC RID: 143580
		private float TimeScale = -1f;

		// Token: 0x0200C1E5 RID: 49637
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403BB79 RID: 244601
			KeyItem,
			// Token: 0x0403BB7A RID: 244602
			SlotItem1,
			// Token: 0x0403BB7B RID: 244603
			SlotItem2,
			// Token: 0x0403BB7C RID: 244604
			SlotItem3,
			// Token: 0x0403BB7D RID: 244605
			SlotItem4,
			// Token: 0x0403BB7E RID: 244606
			SlotItem5,
			// Token: 0x0403BB7F RID: 244607
			SlotItem6,
			// Token: 0x0403BB80 RID: 244608
			PosItem1,
			// Token: 0x0403BB81 RID: 244609
			PosItem2,
			// Token: 0x0403BB82 RID: 244610
			PosItem3,
			// Token: 0x0403BB83 RID: 244611
			PosItem4,
			// Token: 0x0403BB84 RID: 244612
			PosItem5,
			// Token: 0x0403BB85 RID: 244613
			PosItem6,
			// Token: 0x0403BB86 RID: 244614
			AniNoteOffset,
			// Token: 0x0403BB87 RID: 244615
			AniNoteReset,
			// Token: 0x0403BB88 RID: 244616
			AniLock,
			// Token: 0x0403BB89 RID: 244617
			AniDefault,
			// Token: 0x0403BB8A RID: 244618
			AniBurst,
			// Token: 0x0403BB8B RID: 244619
			NoteItem
		}
	}
}
