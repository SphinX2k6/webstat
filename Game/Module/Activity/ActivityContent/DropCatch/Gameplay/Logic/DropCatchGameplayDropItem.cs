using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Views;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic
{
	// Token: 0x02006933 RID: 26931
	[NullableContext(1)]
	[Nullable(0)]
	public class DropCatchGameplayDropItem : IDropItemInstance
	{
		// Token: 0x06042D6A RID: 273770 RVA: 0x01127CD4 File Offset: 0x01125ED4
		public UniTask OnInit(IDropCatchDropItemParams @params)
		{
			DropCatchGameplayDropItem.<OnInit>d__13 <OnInit>d__;
			<OnInit>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnInit>d__.<>4__this = this;
			<OnInit>d__.@params = @params;
			<OnInit>d__.<>1__state = -1;
			<OnInit>d__.<>t__builder.Start<DropCatchGameplayDropItem.<OnInit>d__13>(ref <OnInit>d__);
			return <OnInit>d__.<>t__builder.Task;
		}

		// Token: 0x06042D6B RID: 273771 RVA: 0x01127D20 File Offset: 0x01125F20
		private UniTask InitView()
		{
			DropCatchGameplayDropItem.<InitView>d__14 <InitView>d__;
			<InitView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitView>d__.<>4__this = this;
			<InitView>d__.<>1__state = -1;
			<InitView>d__.<>t__builder.Start<DropCatchGameplayDropItem.<InitView>d__14>(ref <InitView>d__);
			return <InitView>d__.<>t__builder.Task;
		}

		// Token: 0x06042D6C RID: 273772 RVA: 0x01127D63 File Offset: 0x01125F63
		public void OnTick(float deltaTime)
		{
			this.UpdatePosition(deltaTime);
			this.UpdateBounds();
		}

		// Token: 0x06042D6D RID: 273773 RVA: 0x01127D74 File Offset: 0x01125F74
		private void UpdatePosition(float deltaTime)
		{
			double num = this.Pos.Y - (double)(this.Speed * deltaTime);
			if (this.CheckDestroy(num))
			{
				return;
			}
			this.CheckEnableCollision();
			this.Pos.Y = num;
			DropCatchGameplayDropItemView view = this.View;
			if (view == null)
			{
				return;
			}
			view.GetRootItem().SetAnchorOffset(this.Pos.ToUeVector2D(false));
		}

		// Token: 0x06042D6E RID: 273774 RVA: 0x01127DD4 File Offset: 0x01125FD4
		private void UpdateBounds()
		{
			DropCatchGameplayHelper.CalculateBounds(this.Pos, this.ItemSize, this.ItemBounds);
		}

		// Token: 0x06042D6F RID: 273775 RVA: 0x01127DF0 File Offset: 0x01125FF0
		private bool CheckDestroy(double posY)
		{
			if (posY + this.ItemSize.Y / 2.0 < this.Context.GetGameplayArea().MinY)
			{
				this.Context.GetGameplayDropItemMgr().RecycleDropItem(this.InstanceId);
				return true;
			}
			return false;
		}

		// Token: 0x06042D70 RID: 273776 RVA: 0x01127E40 File Offset: 0x01126040
		private void CheckEnableCollision()
		{
			IRoleInstance role = this.Context.GetGameplayRoleMgr().GetRole();
			if (role == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.DropCatch, ELogAuthor.CB, "Role is null", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (this.ItemBounds.Bottom <= role.GetBowlBounds().Top)
			{
				this.Context.GetGameplayCollisionMgr().AddCheckCollisionDropItemInstanceId(this.InstanceId);
				return;
			}
			if (this.ItemBounds.Top < role.GetBowlBounds().Bottom)
			{
				this.Context.GetGameplayCollisionMgr().RemoveCheckCollisionDropItemInstanceId(this.InstanceId);
			}
		}

		// Token: 0x06042D71 RID: 273777 RVA: 0x01127EDE File Offset: 0x011260DE
		public IDropCatchBounds GetItemBounds()
		{
			return this.ItemBounds;
		}

		// Token: 0x06042D72 RID: 273778 RVA: 0x01127EE6 File Offset: 0x011260E6
		public int GetInstanceId()
		{
			return this.InstanceId;
		}

		// Token: 0x06042D73 RID: 273779 RVA: 0x01127EEE File Offset: 0x011260EE
		public int GetItemId()
		{
			return this.ItemId;
		}

		// Token: 0x06042D74 RID: 273780 RVA: 0x01127EF8 File Offset: 0x011260F8
		public unsafe void OnCollision(IRoleInstance role)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.DropCatch;
			ELogAuthor author = ELogAuthor.CB;
			string message = "道具与角色碰撞";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ItemId", this.ItemId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("InstanceId", this.InstanceId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("RoleId", role.GetRoleId());
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			if (this.ItemEffectType == EDropCatchDropItemEffectType.Negative)
			{
				if (role.IsInShield())
				{
					role.RemoveShield();
				}
				else if (role.GetSkillState() != EDropCatchRoleSkillState.InSkill)
				{
					this.ExecuteEffectCommands();
					this.OnAddScore();
					this.OnAddEnergy();
				}
			}
			else
			{
				this.ExecuteEffectCommands();
				this.OnAddScore();
				this.OnAddEnergy();
			}
			this.OnPerformance();
			this.Context.GetGameplayDropItemMgr().RecycleDropItem(this.InstanceId);
			this.Context.GetProxy().AddDropItemRecord(this.ItemTemplate);
		}

		// Token: 0x06042D75 RID: 273781 RVA: 0x0112800B File Offset: 0x0112620B
		protected void OnAddScore()
		{
			if (this.Score == 0)
			{
				return;
			}
			this.Context.GetProxy().AddScore((float)this.Score);
		}

		// Token: 0x06042D76 RID: 273782 RVA: 0x0112802D File Offset: 0x0112622D
		protected void OnAddEnergy()
		{
			IRoleInstance role = this.Context.GetGameplayRoleMgr().GetRole();
			if (role == null)
			{
				return;
			}
			role.AddEnergy((float)this.Energy, true);
		}

		// Token: 0x06042D77 RID: 273783 RVA: 0x01128051 File Offset: 0x01126251
		private void ExecuteEffectCommands()
		{
			this.Context.GetGameplayCommandMgr().ExecuteDropItemEffectCommand(this.ItemId);
		}

		// Token: 0x06042D78 RID: 273784 RVA: 0x0112806C File Offset: 0x0112626C
		protected void OnPerformance()
		{
			if (!(this.NiagaraType != EDropCatchDropItemNiagaraType.High))
			{
				DropCatchGameplayView gameplayView = this.Context.GetProxy().GetGameplayView();
				if (gameplayView != null)
				{
					DropCatchGameplayRoleView roleView = gameplayView.GetRoleView();
					if (roleView != null)
					{
						DropCatchGameplayRoleFxView fxView = roleView.GetFxView();
						if (fxView != null)
						{
							fxView.PlayAdd();
						}
					}
				}
			}
			DropCatchGameplayView gameplayView2 = this.Context.GetProxy().GetGameplayView();
			if (gameplayView2 != null)
			{
				gameplayView2.CreateDropItemFxView(this.NiagaraType.Value, this.Pos);
			}
			EDropCatchItemDefine itemTemplate = (EDropCatchItemDefine)this.ItemTemplate;
			if (itemTemplate == EDropCatchItemDefine.Bomb)
			{
				Singleton<AudioSystem>.Instance.PostEvent("play_ui_goldcatch_efx_debuff");
				return;
			}
			if (itemTemplate - EDropCatchItemDefine.Energy > 2)
			{
				return;
			}
			Singleton<AudioSystem>.Instance.PostEvent("play_ui_goldcatch_com_tip");
		}

		// Token: 0x06042D79 RID: 273785 RVA: 0x01128124 File Offset: 0x01126324
		public void OnRecycle()
		{
			DropCatchGameplayDropItemView view = this.View;
			if (view == null)
			{
				return;
			}
			view.Hide(null);
		}

		// Token: 0x06042D7A RID: 273786 RVA: 0x01128137 File Offset: 0x01126337
		public void Destroy()
		{
			DropCatchGameplayDropItemView view = this.View;
			if (view != null)
			{
				view.Destroy(null);
			}
			this.View = null;
		}

		// Token: 0x040253E3 RID: 152547
		private int InstanceId;

		// Token: 0x040253E4 RID: 152548
		private int ItemId;

		// Token: 0x040253E5 RID: 152549
		private EDropCatchDropItemEffectType ItemEffectType;

		// Token: 0x040253E6 RID: 152550
		private float Speed;

		// Token: 0x040253E7 RID: 152551
		private readonly Vector2D Pos = Vector2D.Create();

		// Token: 0x040253E8 RID: 152552
		private readonly Vector2D ItemSize = Vector2D.Create();

		// Token: 0x040253E9 RID: 152553
		private readonly IDropCatchBounds ItemBounds = new IDropCatchBounds
		{
			Left = 0.0,
			Right = 0.0,
			Top = 0.0,
			Bottom = 0.0
		};

		// Token: 0x040253EA RID: 152554
		[Nullable(2)]
		private DropCatchGameplayDropItemView View;

		// Token: 0x040253EB RID: 152555
		private IGameplayLogicContext Context;

		// Token: 0x040253EC RID: 152556
		private int Score;

		// Token: 0x040253ED RID: 152557
		private int Energy;

		// Token: 0x040253EE RID: 152558
		private EDropCatchDropItemNiagaraType? NiagaraType;

		// Token: 0x040253EF RID: 152559
		private int ItemTemplate;
	}
}
