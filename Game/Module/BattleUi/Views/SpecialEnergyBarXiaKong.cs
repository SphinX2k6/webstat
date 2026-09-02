using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060E7 RID: 24807
	public class SpecialEnergyBarXiaKong : SpecialEnergyBarBase
	{
		// Token: 0x0603EAAF RID: 256687 RVA: 0x0100A640 File Offset: 0x01008840
		protected unsafe override void OnRegisterComponent()
		{
			int num = 14;
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
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603EAB0 RID: 256688 RVA: 0x0100A83C File Offset: 0x01008A3C
		protected override void OnInitData()
		{
			base.OnInitData();
			BattleUiRoleData roleData = this.RoleData;
			CreatureDataComponent creatureDataComponent = (roleData != null) ? roleData.CreatureDataComponent : null;
			if (creatureDataComponent == null)
			{
				return;
			}
			IList<long> customServerEntityIds = creatureDataComponent.CustomServerEntityIds;
			int num = 0;
			while (num < 3 && num <= customServerEntityIds.Count - 1)
			{
				EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(customServerEntityIds[num]);
				if (entity == null || !entity.IsInit)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Battle;
					ELogAuthor author = ELogAuthor.CFT;
					string message = "夏空能量条读取幻影实体时异常";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("creatureDataId", entity);
					instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					this.SummonedList.Add(entity);
				}
				num++;
			}
		}

		// Token: 0x0603EAB1 RID: 256689 RVA: 0x0100A8E4 File Offset: 0x01008AE4
		protected override void AddEvents()
		{
			base.AddEvents();
			foreach (EntityHandle target in this.SummonedList)
			{
				Singleton<EventSystem>.Instance.AddWithTarget<int, bool>(target, EEventName.OnSetActorHidden, new Action<int, bool>(this.OnSummonedHidden));
			}
			base.ListenForTagAddOrRemoveChanged(GameplayTagDefine.EGameplayTagId["角色.R2T1XiakongMd10011.逻辑.乐器.鼓"], new BaseTagComponent.TTagSwitchedCallback(this.OnTag1Change));
			base.ListenForTagAddOrRemoveChanged(GameplayTagDefine.EGameplayTagId["角色.R2T1XiakongMd10011.逻辑.乐器.琴"], new BaseTagComponent.TTagSwitchedCallback(this.OnTag2Change));
			base.ListenForTagAddOrRemoveChanged(GameplayTagDefine.EGameplayTagId["角色.R2T1XiakongMd10011.技能.大招"], new BaseTagComponent.TTagSwitchedCallback(this.OnUltraTagChange));
		}

		// Token: 0x0603EAB2 RID: 256690 RVA: 0x0100A9B8 File Offset: 0x01008BB8
		protected override void RemoveEvents()
		{
			base.RemoveEvents();
			foreach (EntityHandle target in this.SummonedList)
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget<int, bool>(target, EEventName.OnSetActorHidden, new Action<int, bool>(this.OnSummonedHidden));
			}
		}

		// Token: 0x0603EAB3 RID: 256691 RVA: 0x0100AA28 File Offset: 0x01008C28
		private void OnSummonedHidden(int entityId, bool active)
		{
			this.UpdateSummonedEnableCount(false);
		}

		// Token: 0x0603EAB4 RID: 256692 RVA: 0x0100AA31 File Offset: 0x01008C31
		private void OnTag1Change(int tagId, bool tagExist)
		{
			this.ExistTag1 = tagExist;
			this.UpdateSummonedEnableCount(false);
		}

		// Token: 0x0603EAB5 RID: 256693 RVA: 0x0100AA41 File Offset: 0x01008C41
		private void OnTag2Change(int tagId, bool tagExist)
		{
			this.ExistTag2 = tagExist;
			this.UpdateSummonedEnableCount(false);
		}

		// Token: 0x0603EAB6 RID: 256694 RVA: 0x0100AA51 File Offset: 0x01008C51
		private void OnUltraTagChange(int tagId, bool tagExist)
		{
			this.ExistUltraTag = tagExist;
			this.UpdateSummonedEnableCount(false);
		}

		// Token: 0x0603EAB7 RID: 256695 RVA: 0x0100AA64 File Offset: 0x01008C64
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarXiaKong.<OnBeforeStartAsync>d__19 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarXiaKong.<OnBeforeStartAsync>d__19>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603EAB8 RID: 256696 RVA: 0x0100AAA8 File Offset: 0x01008CA8
		protected UniTask InitBarItem()
		{
			SpecialEnergyBarXiaKong.<InitBarItem>d__20 <InitBarItem>d__;
			<InitBarItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBarItem>d__.<>4__this = this;
			<InitBarItem>d__.<>1__state = -1;
			<InitBarItem>d__.<>t__builder.Start<SpecialEnergyBarXiaKong.<InitBarItem>d__20>(ref <InitBarItem>d__);
			return <InitBarItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603EAB9 RID: 256697 RVA: 0x0100AAEC File Offset: 0x01008CEC
		protected override void OnStart()
		{
			base.InitTweenAnim(8);
			base.InitTweenAnim(9);
			base.InitTweenAnim(10);
			base.InitTweenAnim(11);
			base.InitTweenAnim(12);
			base.InitTweenAnim(13);
			this.OnBarPercentChanged();
			BaseTagComponent tagComponent = this.TagComponent;
			this.ExistTag1 = (tagComponent != null && tagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.R2T1XiakongMd10011.逻辑.乐器.鼓"]));
			BaseTagComponent tagComponent2 = this.TagComponent;
			this.ExistTag2 = (tagComponent2 != null && tagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["角色.R2T1XiakongMd10011.逻辑.乐器.琴"]));
			BaseTagComponent tagComponent3 = this.TagComponent;
			this.ExistUltraTag = (tagComponent3 != null && tagComponent3.HasTag(GameplayTagDefine.EGameplayTagId["角色.R2T1XiakongMd10011.技能.大招"]));
			this.UpdateSummonedEnableCount(true);
		}

		// Token: 0x0603EABA RID: 256698 RVA: 0x0100ABAA File Offset: 0x01008DAA
		protected override void OnBarPercentChanged()
		{
			this.SetState(this.GetKeyEnable() ? SpecialEnergyBarXiaKong.EState.Light : SpecialEnergyBarXiaKong.EState.Normal, false);
		}

		// Token: 0x0603EABB RID: 256699 RVA: 0x0100ABC0 File Offset: 0x01008DC0
		private void SetState(SpecialEnergyBarXiaKong.EState state, bool isStart = false)
		{
			if (state == this.CurState && !isStart)
			{
				return;
			}
			this.CurState = state;
			SpecialEnergyBarXiaKong.EState curState = this.CurState;
			if (curState == SpecialEnergyBarXiaKong.EState.Normal)
			{
				base.StopTweenAnim(8);
				base.PlayTweenAnim(9);
				return;
			}
			if (curState != SpecialEnergyBarXiaKong.EState.Light)
			{
				return;
			}
			base.StopTweenAnim(9);
			base.PlayTweenAnim(8);
		}

		// Token: 0x0603EABC RID: 256700 RVA: 0x0100AC0F File Offset: 0x01008E0F
		public override void Tick(float delta)
		{
			base.Tick(delta);
			SpecialEnergyBarSlot barItemNormal = this.BarItemNormal;
			if (barItemNormal == null)
			{
				return;
			}
			barItemNormal.Tick(delta);
		}

		// Token: 0x0603EABD RID: 256701 RVA: 0x0100AC2C File Offset: 0x01008E2C
		private void UpdateSummonedEnableCount(bool isStart = false)
		{
			int num = 0;
			if (this.ExistUltraTag)
			{
				if (this.ExistTag1)
				{
					num++;
				}
				if (this.ExistTag2)
				{
					num++;
				}
			}
			else
			{
				foreach (EntityHandle entityHandle in this.SummonedList)
				{
					WorldEntity entity = entityHandle.Entity;
					BaseActorComponent baseActorComponent = (entity != null) ? entity.GetComponent<BaseActorComponent>() : null;
					if (baseActorComponent != null && baseActorComponent.DisableActorHandle.Empty)
					{
						num++;
					}
				}
				num = Math.Min(num, 2);
			}
			if (this.SummonedEnableCount == num && !isStart)
			{
				return;
			}
			if (num > this.SummonedEnableCount)
			{
				for (int i = this.SummonedEnableCount; i < num; i++)
				{
					if (i == 0)
					{
						base.StopTweenAnim(11);
						base.PlayTweenAnim(10);
					}
					else if (i == 1)
					{
						base.StopTweenAnim(13);
						base.PlayTweenAnim(12);
					}
				}
			}
			else
			{
				for (int j = this.SummonedEnableCount - 1; j >= num; j--)
				{
					if (j == 0)
					{
						base.StopTweenAnim(10);
						base.PlayTweenAnim(11);
					}
					else if (j == 1)
					{
						base.StopTweenAnim(12);
						base.PlayTweenAnim(13);
					}
				}
			}
			this.SummonedEnableCount = num;
		}

		// Token: 0x04023250 RID: 143952
		private const int SUMMON_NUM = 3;

		// Token: 0x04023251 RID: 143953
		private const int MAX_NUM = 2;

		// Token: 0x04023252 RID: 143954
		[Nullable(2)]
		private SpecialEnergyBarSlot BarItemNormal;

		// Token: 0x04023253 RID: 143955
		private SpecialEnergyBarXiaKong.EState CurState;

		// Token: 0x04023254 RID: 143956
		[Nullable(1)]
		private readonly List<EntityHandle> SummonedList = new List<EntityHandle>();

		// Token: 0x04023255 RID: 143957
		private int SummonedEnableCount;

		// Token: 0x04023256 RID: 143958
		private bool ExistTag1;

		// Token: 0x04023257 RID: 143959
		private bool ExistTag2;

		// Token: 0x04023258 RID: 143960
		private bool ExistUltraTag;

		// Token: 0x0200C256 RID: 49750
		private enum EState
		{
			// Token: 0x0403BE72 RID: 245362
			Normal,
			// Token: 0x0403BE73 RID: 245363
			Light
		}

		// Token: 0x0200C257 RID: 49751
		private enum EChildType
		{
			// Token: 0x0403BE75 RID: 245365
			SlotBarItemNormal,
			// Token: 0x0403BE76 RID: 245366
			ItemMid1,
			// Token: 0x0403BE77 RID: 245367
			ItemMid2,
			// Token: 0x0403BE78 RID: 245368
			ItemLeft,
			// Token: 0x0403BE79 RID: 245369
			ItemRight,
			// Token: 0x0403BE7A RID: 245370
			ItemLight,
			// Token: 0x0403BE7B RID: 245371
			ItemBgLeft,
			// Token: 0x0403BE7C RID: 245372
			ItemBgRight,
			// Token: 0x0403BE7D RID: 245373
			AniLightIn,
			// Token: 0x0403BE7E RID: 245374
			AniLightOut,
			// Token: 0x0403BE7F RID: 245375
			AniLeftIn,
			// Token: 0x0403BE80 RID: 245376
			AniLeftOut,
			// Token: 0x0403BE81 RID: 245377
			AniRightIn,
			// Token: 0x0403BE82 RID: 245378
			AniRightOut
		}
	}
}
