using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060A7 RID: 24743
	public class SpecialEnergyBarMotorcycle : SpecialEnergyBarBase
	{
		// Token: 0x0603E77C RID: 255868 RVA: 0x00FF71A8 File Offset: 0x00FF53A8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E77D RID: 255869 RVA: 0x00FF7232 File Offset: 0x00FF5432
		[NullableContext(1)]
		public void InitMotorcycleData(EntityHandle entityHandle, SpecialEnergyBarInfo config)
		{
			this.EntityHandle = entityHandle;
			this.Config = config;
			this.TagComponent = entityHandle.Entity.GetComponent<BaseTagComponent>();
			this.OnInitData();
			this.PercentMachine.Init(0f);
			base.InitKeyEnableTag();
		}

		// Token: 0x0603E77E RID: 255870 RVA: 0x00FF7270 File Offset: 0x00FF5470
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarMotorcycle.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarMotorcycle.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E77F RID: 255871 RVA: 0x00FF72B4 File Offset: 0x00FF54B4
		protected UniTask InitBarItem()
		{
			SpecialEnergyBarMotorcycle.<InitBarItem>d__9 <InitBarItem>d__;
			<InitBarItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBarItem>d__.<>4__this = this;
			<InitBarItem>d__.<>1__state = -1;
			<InitBarItem>d__.<>t__builder.Start<SpecialEnergyBarMotorcycle.<InitBarItem>d__9>(ref <InitBarItem>d__);
			return <InitBarItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603E780 RID: 255872 RVA: 0x00FF72F7 File Offset: 0x00FF54F7
		protected override void OnInitData()
		{
			this.CountMax = (int)this.Config.ExtraFloatParams[0];
		}

		// Token: 0x0603E781 RID: 255873 RVA: 0x00FF7314 File Offset: 0x00FF5514
		protected override void OnStart()
		{
			int tagCount = this.TagComponent.GetTagCount(SpecialEnergyBarMotorcycle.CountTag);
			this.PercentMachine.SetTargetPercent(MathF.Min(1f, (float)tagCount / (float)this.CountMax));
			base.OnStart();
		}

		// Token: 0x0603E782 RID: 255874 RVA: 0x00FF7357 File Offset: 0x00FF5557
		protected override void AddEvents()
		{
			base.AddEvents();
			base.ListenForTagCountChanged(SpecialEnergyBarMotorcycle.CountTag, new BaseTagComponent.TTagChangedCallback(this.OnCountTagChange));
		}

		// Token: 0x0603E783 RID: 255875 RVA: 0x00FF7376 File Offset: 0x00FF5576
		private void OnCountTagChange(int count, int tagId, int exactTagId, int oldCount)
		{
			this.PercentMachine.SetTargetPercent(MathF.Min(1f, (float)count / (float)this.CountMax));
			this.RefreshBarPercent(false);
		}

		// Token: 0x0603E784 RID: 255876 RVA: 0x00FF739E File Offset: 0x00FF559E
		public override void Tick(float delta)
		{
			base.Tick(delta);
			SpecialEnergyBarMotorcycleSlot barItem = this.BarItem;
			if (barItem == null)
			{
				return;
			}
			barItem.Tick(delta);
		}

		// Token: 0x0603E785 RID: 255877 RVA: 0x00FF73B8 File Offset: 0x00FF55B8
		protected override void OnBarPercentChanged()
		{
			this.RefreshBarPercent(false);
		}

		// Token: 0x0603E786 RID: 255878 RVA: 0x00FF73C4 File Offset: 0x00FF55C4
		protected void RefreshBarPercent(bool isStart = false)
		{
			float curPercent = this.PercentMachine.GetCurPercent();
			bool keyEnable = this.GetKeyEnable();
			SpecialEnergyBarMotorcycleSlot barItem = this.BarItem;
			if (barItem != null)
			{
				barItem.UpdatePercent(curPercent, keyEnable, isStart);
			}
			this.SetFullState(keyEnable, isStart);
		}

		// Token: 0x0603E787 RID: 255879 RVA: 0x00FF7400 File Offset: 0x00FF5600
		private void SetFullState(bool isFull, bool isStart = false)
		{
			if (this.IsFull == isFull && !isStart)
			{
				return;
			}
			this.IsFull = isFull;
			base.GetItem(2).SetUIActive(isFull);
			base.GetItem(1).SetUIActive(!isFull);
		}

		// Token: 0x04023042 RID: 143426
		[StaticVariableRuleIgnore]
		private static readonly int CountTag = GameplayTagDefine.EGameplayTagId["关卡.沙虫BOSS战.脉冲炮子弹"];

		// Token: 0x04023043 RID: 143427
		[Nullable(2)]
		private EntityHandle EntityHandle;

		// Token: 0x04023044 RID: 143428
		[Nullable(2)]
		private SpecialEnergyBarMotorcycleSlot BarItem;

		// Token: 0x04023045 RID: 143429
		private bool IsFull;

		// Token: 0x04023046 RID: 143430
		private int CountMax = 100;

		// Token: 0x0200C1BB RID: 49595
		private enum EChildType
		{
			// Token: 0x0403BA56 RID: 244310
			SlotBarItem,
			// Token: 0x0403BA57 RID: 244311
			NormalItem,
			// Token: 0x0403BA58 RID: 244312
			FullItem
		}
	}
}
