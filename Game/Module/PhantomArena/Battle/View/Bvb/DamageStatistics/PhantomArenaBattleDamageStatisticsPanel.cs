using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.Bvb.DamageStatistics
{
	// Token: 0x020055DF RID: 21983
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaBattleDamageStatisticsPanel : UiPanelBase
	{
		// Token: 0x06038046 RID: 229446 RVA: 0x00E30E80 File Offset: 0x00E2F080
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(6, typeof(UUIExtendToggle))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickDamageRank)),
				new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnClickInjuryRank)),
				new ValueTuple<int, Delegate>(5, new Action<EToggleState>(this.OnClickSwitchContent)),
				new ValueTuple<int, Delegate>(6, new Action<EToggleState>(this.OnClickSwitchShow))
			};
		}

		// Token: 0x06038047 RID: 229447 RVA: 0x00E30FA0 File Offset: 0x00E2F1A0
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaBattleDamageStatisticsPanel.<OnBeforeStartAsync>d__19 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaBattleDamageStatisticsPanel.<OnBeforeStartAsync>d__19>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06038048 RID: 229448 RVA: 0x00E30FE3 File Offset: 0x00E2F1E3
		protected override void OnStart()
		{
			this.InitTween();
			this.InitSequence();
			this.InitToggle();
			this.InitContentHeight();
			this.HideTemplateItem();
		}

		// Token: 0x06038049 RID: 229449 RVA: 0x00E31003 File Offset: 0x00E2F203
		protected override void OnBeforeDestroy()
		{
			this.Sequence.Clear();
			this.HeightTween.Destroy();
		}

		// Token: 0x0603804A RID: 229450 RVA: 0x00E3101B File Offset: 0x00E2F21B
		public void Tick(float deltaTime)
		{
			this.HandleNotifyValueChange();
		}

		// Token: 0x0603804B RID: 229451 RVA: 0x00E31023 File Offset: 0x00E2F223
		private void InitTween()
		{
			this.HeightTween = new LguiIntTween();
			this.HeightTween.BindUpdateTween(new Action<int>(this.UpdateLayoutHeight));
		}

		// Token: 0x0603804C RID: 229452 RVA: 0x00E31047 File Offset: 0x00E2F247
		private void InitSequence()
		{
			this.Sequence = new UiSequencePlayer(this.RootItem);
			this.Sequence.BindOnEndSequenceEvent(new Action<string>(this.OnEndSequenceEvent));
		}

		// Token: 0x0603804D RID: 229453 RVA: 0x00E31074 File Offset: 0x00E2F274
		private void InitToggle()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			UUIExtendToggle extendToggle2 = base.GetExtendToggle(1);
			extendToggle.CanExecuteChange.Bind(new Func<bool>(this.CanDamageExecuteChange));
			extendToggle2.CanExecuteChange.Bind(new Func<bool>(this.CanInjuryExecuteChange));
			List<long> allEntityIdList = ModelBase<PhantomArenaBattleModel>.Instance.BattleData.GetAllEntityIdList();
			base.GetExtendToggle(5).RootUIComp.Get().SetUIActive(allEntityIdList.Count > 3);
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, true, false, false);
		}

		// Token: 0x0603804E RID: 229454 RVA: 0x00E31100 File Offset: 0x00E2F300
		private void InitContentHeight()
		{
			this.ContentItem = base.GetItem(3);
			this.OriginalHeight = this.ContentItem.Height;
			this.ContentItem.SetHeight(this.OriginalHeight + (this.GridItemHeight + 12f) * 2f);
		}

		// Token: 0x0603804F RID: 229455 RVA: 0x00E3114F File Offset: 0x00E2F34F
		private void HideTemplateItem()
		{
			base.GetItem(4).SetUIActive(false);
		}

		// Token: 0x06038050 RID: 229456 RVA: 0x00E31160 File Offset: 0x00E2F360
		private UniTask InitMoveCurve()
		{
			PhantomArenaBattleDamageStatisticsPanel.<InitMoveCurve>d__28 <InitMoveCurve>d__;
			<InitMoveCurve>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitMoveCurve>d__.<>4__this = this;
			<InitMoveCurve>d__.<>1__state = -1;
			<InitMoveCurve>d__.<>t__builder.Start<PhantomArenaBattleDamageStatisticsPanel.<InitMoveCurve>d__28>(ref <InitMoveCurve>d__);
			return <InitMoveCurve>d__.<>t__builder.Task;
		}

		// Token: 0x06038051 RID: 229457 RVA: 0x00E311A4 File Offset: 0x00E2F3A4
		private UUIItem CreateItemActor()
		{
			UUIItem item = base.GetItem(4);
			return Singleton<LguiUtil>.Instance.CopyItem(item, base.GetItem(3));
		}

		// Token: 0x06038052 RID: 229458 RVA: 0x00E311CC File Offset: 0x00E2F3CC
		private UniTask InitLayout()
		{
			PhantomArenaBattleDamageStatisticsPanel.<InitLayout>d__30 <InitLayout>d__;
			<InitLayout>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitLayout>d__.<>4__this = this;
			<InitLayout>d__.<>1__state = -1;
			<InitLayout>d__.<>t__builder.Start<PhantomArenaBattleDamageStatisticsPanel.<InitLayout>d__30>(ref <InitLayout>d__);
			return <InitLayout>d__.<>t__builder.Task;
		}

		// Token: 0x06038053 RID: 229459 RVA: 0x00E3120F File Offset: 0x00E2F40F
		private void InitGridItemHeight()
		{
			this.GridItemHeight = base.GetItem(4).Height;
		}

		// Token: 0x06038054 RID: 229460 RVA: 0x00E31223 File Offset: 0x00E2F423
		private void HandleNotifyValueChange()
		{
			if (this.IsNotifyValueChange)
			{
				this.IsNotifyValueChange = false;
				this.RefreshContent();
			}
		}

		// Token: 0x06038055 RID: 229461 RVA: 0x00E3123C File Offset: 0x00E2F43C
		private void RefreshContent()
		{
			List<IDamageData> list = this.DamageDataMap[this.SelectRankType].Values.ToList<IDamageData>();
			list.Sort((IDamageData a, IDamageData b) => b.Damage - a.Damage);
			for (int i = 0; i < list.Count; i++)
			{
				IDamageData damageData = list[i];
				PhantomArenaBattleDamageStatisticsItem phantomArenaBattleDamageStatisticsItem = this.LayoutItemMap[damageData.EntityId];
				float offsetY = this.DefaultOffsetY - (float)i * (this.GridItemHeight + 12f);
				phantomArenaBattleDamageStatisticsItem.RefreshOffsetY(offsetY);
				phantomArenaBattleDamageStatisticsItem.RefreshCount();
			}
		}

		// Token: 0x06038056 RID: 229462 RVA: 0x00E312D8 File Offset: 0x00E2F4D8
		private UniTask CreateDamageStatisticsItem(long entityId, int index)
		{
			PhantomArenaBattleDamageStatisticsPanel.<CreateDamageStatisticsItem>d__34 <CreateDamageStatisticsItem>d__;
			<CreateDamageStatisticsItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateDamageStatisticsItem>d__.<>4__this = this;
			<CreateDamageStatisticsItem>d__.entityId = entityId;
			<CreateDamageStatisticsItem>d__.index = index;
			<CreateDamageStatisticsItem>d__.<>1__state = -1;
			<CreateDamageStatisticsItem>d__.<>t__builder.Start<PhantomArenaBattleDamageStatisticsPanel.<CreateDamageStatisticsItem>d__34>(ref <CreateDamageStatisticsItem>d__);
			return <CreateDamageStatisticsItem>d__.<>t__builder.Task;
		}

		// Token: 0x06038057 RID: 229463 RVA: 0x00E3132B File Offset: 0x00E2F52B
		private void OnEndSequenceEvent(string sequenceName)
		{
			if (sequenceName == "Close")
			{
				base.GetItem(2).SetUIActive(false);
			}
		}

		// Token: 0x06038058 RID: 229464 RVA: 0x00E31347 File Offset: 0x00E2F547
		private bool CanDamageExecuteChange()
		{
			return this.SelectRankType != EDamageStatisticsRankType.Damage;
		}

		// Token: 0x06038059 RID: 229465 RVA: 0x00E31355 File Offset: 0x00E2F555
		private bool CanInjuryExecuteChange()
		{
			return this.SelectRankType != EDamageStatisticsRankType.Injury;
		}

		// Token: 0x0603805A RID: 229466 RVA: 0x00E31363 File Offset: 0x00E2F563
		private void OnClickDamageRank(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				this.SelectRankType = EDamageStatisticsRankType.Damage;
				base.GetExtendToggle(1).SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
				this.RefreshContent();
			}
		}

		// Token: 0x0603805B RID: 229467 RVA: 0x00E31386 File Offset: 0x00E2F586
		private void OnClickInjuryRank(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				this.SelectRankType = EDamageStatisticsRankType.Injury;
				base.GetExtendToggle(0).SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
				this.RefreshContent();
			}
		}

		// Token: 0x0603805C RID: 229468 RVA: 0x00E313AC File Offset: 0x00E2F5AC
		private void OnClickSwitchContent(EToggleState state)
		{
			float height = base.GetItem(3).Height;
			float num;
			if (state == EToggleState.ETT_Checked)
			{
				num = this.OriginalHeight + (this.GridItemHeight + 12f) * (float)(this.LayoutItemMap.Count - 1);
			}
			else
			{
				num = this.OriginalHeight + (this.GridItemHeight + 12f) * 2f;
			}
			this.HeightTween.PlayTween((int)height, (int)num, 0.3f, this.LerpCurve);
		}

		// Token: 0x0603805D RID: 229469 RVA: 0x00E3142C File Offset: 0x00E2F62C
		private void OnClickSwitchShow(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				this.Sequence.StopSequenceByKey("Close", false, true);
				base.GetItem(2).SetUIActive(true);
				this.Sequence.PlaySequence("Start", false, null);
				return;
			}
			this.Sequence.StopSequenceByKey("Start", false, true);
			this.Sequence.PlaySequence("Close", false, null);
		}

		// Token: 0x0603805E RID: 229470 RVA: 0x00E314A4 File Offset: 0x00E2F6A4
		private void NotifyValueChange(long entityId, int damageValue, int hpValue, EDamageStatisticsRankType rankType)
		{
			if (rankType == EDamageStatisticsRankType.Injury)
			{
				this.AllInjury += damageValue;
				this.DamageDataMap[EDamageStatisticsRankType.Injury][entityId].Damage += damageValue;
			}
			else if (rankType == EDamageStatisticsRankType.Damage)
			{
				this.AllDamage += damageValue;
				this.DamageDataMap[EDamageStatisticsRankType.Damage][entityId].Damage += damageValue;
			}
			if (rankType != this.SelectRankType)
			{
				return;
			}
			if ((float)damageValue / (float)hpValue <= 0.01f)
			{
				return;
			}
			this.IsNotifyValueChange = true;
		}

		// Token: 0x0603805F RID: 229471 RVA: 0x00E31536 File Offset: 0x00E2F736
		private int GetAllCount()
		{
			if (this.SelectRankType == EDamageStatisticsRankType.Damage)
			{
				return this.AllDamage;
			}
			return this.AllInjury;
		}

		// Token: 0x06038060 RID: 229472 RVA: 0x00E3154E File Offset: 0x00E2F74E
		private int GetCount(long entityId)
		{
			if (this.SelectRankType == EDamageStatisticsRankType.Damage)
			{
				return this.DamageDataMap[EDamageStatisticsRankType.Damage][entityId].Damage;
			}
			return this.DamageDataMap[EDamageStatisticsRankType.Injury][entityId].Damage;
		}

		// Token: 0x06038061 RID: 229473 RVA: 0x00E31588 File Offset: 0x00E2F788
		private void UpdateLayoutHeight(int value)
		{
			this.ContentItem.SetHeight((float)value);
		}

		// Token: 0x04020077 RID: 131191
		private const int LIMIT_MIN_NUM = 3;

		// Token: 0x04020078 RID: 131192
		private const float LIMIT_DAMAGE_RATE = 0.01f;

		// Token: 0x04020079 RID: 131193
		private const int ITEM_HEIGHT_INTERVAL = 12;

		// Token: 0x0402007A RID: 131194
		private const float TWEEN_DURATION = 0.3f;

		// Token: 0x0402007B RID: 131195
		protected EDamageStatisticsRankType SelectRankType;

		// Token: 0x0402007C RID: 131196
		protected UiSequencePlayer Sequence;

		// Token: 0x0402007D RID: 131197
		protected Dictionary<long, PhantomArenaBattleDamageStatisticsItem> LayoutItemMap = new Dictionary<long, PhantomArenaBattleDamageStatisticsItem>();

		// Token: 0x0402007E RID: 131198
		protected float GridItemHeight;

		// Token: 0x0402007F RID: 131199
		protected float OriginalHeight;

		// Token: 0x04020080 RID: 131200
		protected int AllDamage;

		// Token: 0x04020081 RID: 131201
		protected int AllInjury;

		// Token: 0x04020082 RID: 131202
		protected Dictionary<EDamageStatisticsRankType, Dictionary<long, IDamageData>> DamageDataMap = new Dictionary<EDamageStatisticsRankType, Dictionary<long, IDamageData>>();

		// Token: 0x04020083 RID: 131203
		protected bool IsNotifyValueChange;

		// Token: 0x04020084 RID: 131204
		protected UCurveFloat LerpCurve;

		// Token: 0x04020085 RID: 131205
		protected float DefaultOffsetY;

		// Token: 0x04020086 RID: 131206
		protected LguiIntTween HeightTween;

		// Token: 0x04020087 RID: 131207
		protected UUIItem ContentItem;

		// Token: 0x0200B5E6 RID: 46566
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x04038485 RID: 230533
			public const int DamageRankToggle = 0;

			// Token: 0x04038486 RID: 230534
			public const int InjuryRankToggle = 1;

			// Token: 0x04038487 RID: 230535
			public const int ContentRootItem = 2;

			// Token: 0x04038488 RID: 230536
			public const int ContentItem = 3;

			// Token: 0x04038489 RID: 230537
			public const int TemplateItem = 4;

			// Token: 0x0403848A RID: 230538
			public const int SwitchContentToggle = 5;

			// Token: 0x0403848B RID: 230539
			public const int SwitchShowToggle = 6;
		}
	}
}
