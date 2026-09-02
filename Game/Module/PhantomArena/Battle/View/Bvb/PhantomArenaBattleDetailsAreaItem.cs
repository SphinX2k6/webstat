using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.PhantomArena.Battle.View.Field;
using CSharpScript.Game.Module.PhantomArena.Battle.View.Panel;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.Bvb
{
	// Token: 0x020055D2 RID: 21970
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaBattleDetailsAreaItem : UiPanelBase
	{
		// Token: 0x06037F88 RID: 229256 RVA: 0x00E2D388 File Offset: 0x00E2B588
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUILayoutBase)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem))
			};
		}

		// Token: 0x06037F89 RID: 229257 RVA: 0x00E2D43C File Offset: 0x00E2B63C
		private UniTask InitMonster()
		{
			PhantomArenaBattleDetailsAreaItem.<InitMonster>d__11 <InitMonster>d__;
			<InitMonster>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitMonster>d__.<>4__this = this;
			<InitMonster>d__.<>1__state = -1;
			<InitMonster>d__.<>t__builder.Start<PhantomArenaBattleDetailsAreaItem.<InitMonster>d__11>(ref <InitMonster>d__);
			return <InitMonster>d__.<>t__builder.Task;
		}

		// Token: 0x06037F8A RID: 229258 RVA: 0x00E2D480 File Offset: 0x00E2B680
		private UniTask InitBossItem()
		{
			PhantomArenaBattleDetailsAreaItem.<InitBossItem>d__12 <InitBossItem>d__;
			<InitBossItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBossItem>d__.<>4__this = this;
			<InitBossItem>d__.<>1__state = -1;
			<InitBossItem>d__.<>t__builder.Start<PhantomArenaBattleDetailsAreaItem.<InitBossItem>d__12>(ref <InitBossItem>d__);
			return <InitBossItem>d__.<>t__builder.Task;
		}

		// Token: 0x06037F8B RID: 229259 RVA: 0x00E2D4C4 File Offset: 0x00E2B6C4
		private UniTask InitSkillItem()
		{
			PhantomArenaBattleDetailsAreaItem.<InitSkillItem>d__13 <InitSkillItem>d__;
			<InitSkillItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitSkillItem>d__.<>4__this = this;
			<InitSkillItem>d__.<>1__state = -1;
			<InitSkillItem>d__.<>t__builder.Start<PhantomArenaBattleDetailsAreaItem.<InitSkillItem>d__13>(ref <InitSkillItem>d__);
			return <InitSkillItem>d__.<>t__builder.Task;
		}

		// Token: 0x06037F8C RID: 229260 RVA: 0x00E2D508 File Offset: 0x00E2B708
		private UniTask InitDetailsTipsItem()
		{
			PhantomArenaBattleDetailsAreaItem.<InitDetailsTipsItem>d__14 <InitDetailsTipsItem>d__;
			<InitDetailsTipsItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitDetailsTipsItem>d__.<>4__this = this;
			<InitDetailsTipsItem>d__.<>1__state = -1;
			<InitDetailsTipsItem>d__.<>t__builder.Start<PhantomArenaBattleDetailsAreaItem.<InitDetailsTipsItem>d__14>(ref <InitDetailsTipsItem>d__);
			return <InitDetailsTipsItem>d__.<>t__builder.Task;
		}

		// Token: 0x06037F8D RID: 229261 RVA: 0x00E2D54C File Offset: 0x00E2B74C
		private UniTask InitFieldItem()
		{
			PhantomArenaBattleDetailsAreaItem.<InitFieldItem>d__15 <InitFieldItem>d__;
			<InitFieldItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitFieldItem>d__.<>4__this = this;
			<InitFieldItem>d__.<>1__state = -1;
			<InitFieldItem>d__.<>t__builder.Start<PhantomArenaBattleDetailsAreaItem.<InitFieldItem>d__15>(ref <InitFieldItem>d__);
			return <InitFieldItem>d__.<>t__builder.Task;
		}

		// Token: 0x06037F8E RID: 229262 RVA: 0x00E2D590 File Offset: 0x00E2B790
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaBattleDetailsAreaItem.<OnBeforeStartAsync>d__16 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaBattleDetailsAreaItem.<OnBeforeStartAsync>d__16>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037F8F RID: 229263 RVA: 0x00E2D5D3 File Offset: 0x00E2B7D3
		private PhantomArenaBattleDetailsMonsterItem InitMonsterItem()
		{
			PhantomArenaBattleDetailsMonsterItem phantomArenaBattleDetailsMonsterItem = new PhantomArenaBattleDetailsMonsterItem();
			phantomArenaBattleDetailsMonsterItem.IsOwn = this.IsOwn;
			phantomArenaBattleDetailsMonsterItem.OnClickCb = new Action<long>(this.OnClickMonsterItem);
			phantomArenaBattleDetailsMonsterItem.RegisterProxy(this.Proxy);
			return phantomArenaBattleDetailsMonsterItem;
		}

		// Token: 0x06037F90 RID: 229264 RVA: 0x00E2D604 File Offset: 0x00E2B804
		private void FieldInteractClick(PhantomArenaFieldData fieldData, PhantomArenaFieldItem fieldItem)
		{
			this.DetailsTipsItem.SetUiActive(true);
			this.DetailsTipsItem.RefreshByCardData(fieldData.CardData);
		}

		// Token: 0x06037F91 RID: 229265 RVA: 0x00E2D623 File Offset: 0x00E2B823
		public void RegisterProxy(PhantomArenaBattleDetailsViewProxy proxy)
		{
			this.Proxy = proxy;
		}

		// Token: 0x06037F92 RID: 229266 RVA: 0x00E2D62C File Offset: 0x00E2B82C
		public void SetSettlePoint(int settlePoint)
		{
			this.SkillItem.RefreshSettlePointText(settlePoint);
		}

		// Token: 0x06037F93 RID: 229267 RVA: 0x00E2D63C File Offset: 0x00E2B83C
		public void TickMonster(float deltaTime)
		{
			if (this.IsBattleEnd)
			{
				return;
			}
			foreach (PhantomArenaBattleDetailsMonsterItem phantomArenaBattleDetailsMonsterItem in this.Layout.GetLayoutItemList())
			{
				phantomArenaBattleDetailsMonsterItem.Tick(deltaTime);
			}
		}

		// Token: 0x06037F94 RID: 229268 RVA: 0x00E2D69C File Offset: 0x00E2B89C
		public int GetBeforeDamage()
		{
			int num = 0;
			num += this.SkillItem.GetDamage();
			foreach (PhantomArenaBattleDetailsMonsterItem phantomArenaBattleDetailsMonsterItem in this.Layout.GetLayoutItemList())
			{
				num += phantomArenaBattleDetailsMonsterItem.GetDamage();
			}
			return num;
		}

		// Token: 0x06037F95 RID: 229269 RVA: 0x00E2D708 File Offset: 0x00E2B908
		public bool GetPhantomAlive()
		{
			int num = 0;
			foreach (PhantomArenaBattleDetailsMonsterItem phantomArenaBattleDetailsMonsterItem in this.Layout.GetLayoutItemList())
			{
				num += phantomArenaBattleDetailsMonsterItem.GetDamage();
			}
			return num > 0;
		}

		// Token: 0x06037F96 RID: 229270 RVA: 0x00E2D768 File Offset: 0x00E2B968
		public void StartShowWinAnim()
		{
			this.IsBattleEnd = true;
			List<PhantomArenaBattleDetailsMonsterItem> layoutItemList = this.Layout.GetLayoutItemList();
			this.SkillItem.ShowWinAnim();
			foreach (PhantomArenaBattleDetailsMonsterItem phantomArenaBattleDetailsMonsterItem in layoutItemList)
			{
				phantomArenaBattleDetailsMonsterItem.ShowWinAnim();
			}
		}

		// Token: 0x06037F97 RID: 229271 RVA: 0x00E2D7D4 File Offset: 0x00E2B9D4
		public void StartAccumulate(UCurveFloat curveX, UCurveFloat curveY, UCurveFloat curveCommon)
		{
			List<PhantomArenaBattleDetailsMonsterItem> layoutItemList = this.Layout.GetLayoutItemList();
			FVectorDouble headLocation = this.RoleItem.GetHeadLocation();
			PhantomArenaBattleDetailsSkillItem skillItem = this.SkillItem;
			if (skillItem != null)
			{
				skillItem.OnAccumulateEvent((float)headLocation.X, (float)headLocation.Z, curveCommon);
			}
			foreach (PhantomArenaBattleDetailsMonsterItem phantomArenaBattleDetailsMonsterItem in layoutItemList)
			{
				phantomArenaBattleDetailsMonsterItem.OnAccumulateEvent((float)headLocation.X, (float)headLocation.Z, curveX, curveY);
			}
			TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				PhantomArenaBattleDetailsRoleItem roleItem = this.RoleItem;
				if (roleItem == null)
				{
					return;
				}
				roleItem.OnAccumulateAfterEvent();
			}, 200f, null, null, true, 1f);
		}

		// Token: 0x06037F98 RID: 229272 RVA: 0x00E2D88C File Offset: 0x00E2BA8C
		public FVectorDouble GetHeadLocation()
		{
			return this.RoleItem.GetHeadLocation();
		}

		// Token: 0x06037F99 RID: 229273 RVA: 0x00E2D899 File Offset: 0x00E2BA99
		public void SetDamageTween(UCurveFloat curve, int damage)
		{
			PhantomArenaBattleDetailsRoleItem roleItem = this.RoleItem;
			if (roleItem == null)
			{
				return;
			}
			roleItem.RefreshLifeAfterDamage(curve, damage);
		}

		// Token: 0x06037F9A RID: 229274 RVA: 0x00E2D8AD File Offset: 0x00E2BAAD
		public void SetHitNum(int damage)
		{
			PhantomArenaBattleDetailsRoleItem roleItem = this.RoleItem;
			if (roleItem == null)
			{
				return;
			}
			roleItem.SetHitNum(damage);
		}

		// Token: 0x06037F9B RID: 229275 RVA: 0x00E2D8C0 File Offset: 0x00E2BAC0
		private void OnClickMonsterItem(long entityId)
		{
			PhantomCardData cardDataByEntityId = ModelBase<PhantomArenaBattleModel>.Instance.BattleData.GetCardDataByEntityId(entityId);
			this.DetailsTipsItem.SetUiActive(true);
			this.DetailsTipsItem.RefreshByCardData(cardDataByEntityId);
		}

		// Token: 0x06037F9C RID: 229276 RVA: 0x00E2D8F6 File Offset: 0x00E2BAF6
		private void ClickMonsterTipsHide()
		{
			this.DetailsTipsItem.SetUiActive(false);
		}

		// Token: 0x04020011 RID: 131089
		protected GenericLayout<PhantomArenaBattleDetailsMonsterItem, long> Layout;

		// Token: 0x04020012 RID: 131090
		public PhantomArenaBattleDetailsRoleItem RoleItem;

		// Token: 0x04020013 RID: 131091
		protected PhantomArenaBattleDetailsSkillItem SkillItem;

		// Token: 0x04020014 RID: 131092
		protected PhantomArenaFieldItem FieldItem;

		// Token: 0x04020015 RID: 131093
		protected PhantomArenaBattleDetailsViewProxy Proxy;

		// Token: 0x04020016 RID: 131094
		public bool IsOwn;

		// Token: 0x04020017 RID: 131095
		public List<long> EntityIdList = new List<long>();

		// Token: 0x04020018 RID: 131096
		protected bool IsBattleEnd;

		// Token: 0x04020019 RID: 131097
		protected PhantomArenaBattleDetailsTips DetailsTipsItem;

		// Token: 0x0200B5C4 RID: 46532
		[NullableContext(0)]
		private class EAreaItem
		{
			// Token: 0x040383E5 RID: 230373
			public const int RoleItem = 0;

			// Token: 0x040383E6 RID: 230374
			public const int Layout = 1;

			// Token: 0x040383E7 RID: 230375
			public const int LayoutItem = 2;

			// Token: 0x040383E8 RID: 230376
			public const int SkillItem = 3;

			// Token: 0x040383E9 RID: 230377
			public const int PanelCardTips = 4;

			// Token: 0x040383EA RID: 230378
			public const int FieldRoot = 5;

			// Token: 0x040383EB RID: 230379
			public const int FieldItem = 6;
		}
	}
}
