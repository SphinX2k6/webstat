using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006093 RID: 24723
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleUniqueBuffView : BattleVisibleChildView
	{
		// Token: 0x0603E63A RID: 255546 RVA: 0x00FEF38C File Offset: 0x00FED58C
		protected override void OnStart()
		{
			base.OnStart();
			base.InitChildType(EBattleUiChild.Ignore);
			this.InitExceedTipItem();
			int value = ConfigCommonParamById.GetIntConfig("RoleUniqueBuffItemCount").Value;
			this.BuffItemContainer.Init(this.RootItem, value, false, true, true, this.ExceedTipItem.GetRootItem());
			this.AddEvents();
		}

		// Token: 0x0603E63B RID: 255547 RVA: 0x00FEF3E8 File Offset: 0x00FED5E8
		protected override void OnBeforeDestroy()
		{
			this.Refresh(null);
			this.DestroyExceedTipItem();
			this.CurRoleBar = null;
			foreach (TopBuffContainer topBuffContainer in this.RoleBarMap.Values)
			{
				topBuffContainer.Destroy();
			}
		}

		// Token: 0x0603E63C RID: 255548 RVA: 0x00FEF454 File Offset: 0x00FED654
		public override void Reset()
		{
			this.RemoveEvents();
			base.Reset();
		}

		// Token: 0x0603E63D RID: 255549 RVA: 0x00FEF462 File Offset: 0x00FED662
		private void InitExceedTipItem()
		{
			this.ExceedTipItem = new BuffItem(this.RootItem);
			this.ExceedTipItem.ActivateExceedTip();
		}

		// Token: 0x0603E63E RID: 255550 RVA: 0x00FEF480 File Offset: 0x00FED680
		private void DestroyExceedTipItem()
		{
			if (this.ExceedTipItem != null)
			{
				this.ExceedTipItem.DestroyCompatible();
				this.ExceedTipItem = null;
			}
		}

		// Token: 0x0603E63F RID: 255551 RVA: 0x00FEF49C File Offset: 0x00FED69C
		[NullableContext(2)]
		public void Refresh(BattleUiRoleData roleData)
		{
			int? num;
			if (roleData == null)
			{
				num = null;
			}
			else
			{
				EntityHandle entityHandle = roleData.EntityHandle;
				num = ((entityHandle != null) ? new int?(entityHandle.Id) : null);
			}
			int? num2 = num;
			this.EntityId = new int?(num2.GetValueOrDefault());
			if (roleData != null)
			{
				this.BuffItemContainer.RefreshBuff(roleData.EntityHandle);
				this.LoadRoleTopBuff(roleData).Forget();
			}
			else
			{
				this.BuffItemContainer.ClearAll();
			}
			this.RefreshAllRoleTopBuffVisible();
		}

		// Token: 0x0603E640 RID: 255552 RVA: 0x00FEF51C File Offset: 0x00FED71C
		public void Tick(float delta)
		{
			this.BuffItemContainer.Tick(delta);
			foreach (TopBuffContainer topBuffContainer in this.RoleBarMap.Values)
			{
				topBuffContainer.Tick(delta);
			}
		}

		// Token: 0x0603E641 RID: 255553 RVA: 0x00FEF580 File Offset: 0x00FED780
		public void AddBuff(GameplayCue buffCueConfig, int handleId)
		{
			this.BuffItemContainer.AddBuffByCue(buffCueConfig, handleId, true);
		}

		// Token: 0x0603E642 RID: 255554 RVA: 0x00FEF590 File Offset: 0x00FED790
		public void RemoveBuff(GameplayCue buffCueConfig, int handleId)
		{
			this.BuffItemContainer.RemoveBuffByCue(buffCueConfig, handleId, true);
		}

		// Token: 0x0603E643 RID: 255555 RVA: 0x00FEF5A4 File Offset: 0x00FED7A4
		public void OnRemoveEntity(int entityId)
		{
			TopBuffContainer topBuffContainer;
			if (this.RoleBarMap.Remove(entityId, out topBuffContainer))
			{
				topBuffContainer.Destroy();
				if (this.CurRoleBar == topBuffContainer)
				{
					this.CurRoleBar = null;
					return;
				}
			}
			else
			{
				this.NoRoleBarSet.Remove(entityId);
			}
		}

		// Token: 0x0603E644 RID: 255556 RVA: 0x00FEF5E5 File Offset: 0x00FED7E5
		private void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.BattleUiAllRoleDataChanged, new Action(this.OnFormationLoaded));
		}

		// Token: 0x0603E645 RID: 255557 RVA: 0x00FEF603 File Offset: 0x00FED803
		private void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiAllRoleDataChanged, new Action(this.OnFormationLoaded));
		}

		// Token: 0x0603E646 RID: 255558 RVA: 0x00FEF621 File Offset: 0x00FED821
		private void OnFormationLoaded()
		{
			this.LoadAllRoleTopBuff();
			this.RefreshAllRoleTopBuffVisible();
		}

		// Token: 0x0603E647 RID: 255559 RVA: 0x00FEF630 File Offset: 0x00FED830
		private void LoadAllRoleTopBuff()
		{
			foreach (SceneTeamItem sceneTeamItem in ModelBase<SceneTeamModel>.Instance.GetTeamItems(true))
			{
				EntityHandle entityHandle = sceneTeamItem.EntityHandle;
				int? num = (entityHandle != null) ? new int?(entityHandle.Id) : null;
				if (num != null)
				{
					BattleUiRoleData roleData = ModelBase<BattleUiModel>.Instance.GetRoleData(num.Value);
					if (roleData != null)
					{
						this.LoadRoleTopBuff(roleData).Forget();
					}
				}
			}
		}

		// Token: 0x0603E648 RID: 255560 RVA: 0x00FEF6CC File Offset: 0x00FED8CC
		private UniTask LoadRoleTopBuff(BattleUiRoleData roleData)
		{
			RoleUniqueBuffView.<LoadRoleTopBuff>d__21 <LoadRoleTopBuff>d__;
			<LoadRoleTopBuff>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadRoleTopBuff>d__.<>4__this = this;
			<LoadRoleTopBuff>d__.roleData = roleData;
			<LoadRoleTopBuff>d__.<>1__state = -1;
			<LoadRoleTopBuff>d__.<>t__builder.Start<RoleUniqueBuffView.<LoadRoleTopBuff>d__21>(ref <LoadRoleTopBuff>d__);
			return <LoadRoleTopBuff>d__.<>t__builder.Task;
		}

		// Token: 0x0603E649 RID: 255561 RVA: 0x00FEF718 File Offset: 0x00FED918
		private void RefreshAllRoleTopBuffVisible()
		{
			foreach (KeyValuePair<int, TopBuffContainer> keyValuePair in this.RoleBarMap)
			{
				int num;
				TopBuffContainer topBuffContainer;
				keyValuePair.Deconstruct(out num, out topBuffContainer);
				int num2 = num;
				TopBuffContainer topBuffContainer2 = topBuffContainer;
				int? entityId = this.EntityId;
				if (num2 == entityId.GetValueOrDefault() & entityId != null)
				{
					topBuffContainer2.SetVisible(true);
					this.CurRoleBar = topBuffContainer2;
				}
				else
				{
					topBuffContainer2.SetVisible(false);
				}
			}
		}

		// Token: 0x0603E64B RID: 255563 RVA: 0x00FEF7D1 File Offset: 0x00FED9D1
		// Note: this type is marked as 'beforefieldinit'.
		static RoleUniqueBuffView()
		{
			Dictionary<int, Type> dictionary = new Dictionary<int, Type>();
			dictionary[1106] = typeof(TopBuffYouHu);
			dictionary[1307] = typeof(TopBuffBuLing);
			RoleUniqueBuffView.RoleClassMap = dictionary;
		}

		// Token: 0x04022F66 RID: 143206
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<int, Type> RoleClassMap;

		// Token: 0x04022F67 RID: 143207
		private readonly BuffItemContainer BuffItemContainer = new BuffItemContainer();

		// Token: 0x04022F68 RID: 143208
		[Nullable(2)]
		private BuffItem ExceedTipItem;

		// Token: 0x04022F69 RID: 143209
		private int? EntityId;

		// Token: 0x04022F6A RID: 143210
		[Nullable(2)]
		private TopBuffContainer CurRoleBar;

		// Token: 0x04022F6B RID: 143211
		private readonly Dictionary<int, TopBuffContainer> RoleBarMap = new Dictionary<int, TopBuffContainer>();

		// Token: 0x04022F6C RID: 143212
		private readonly HashSet<int> NoRoleBarSet = new HashSet<int>();
	}
}
