using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.Panel
{
	// Token: 0x020055C1 RID: 21953
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaRoleItem : UiPanelBase
	{
		// Token: 0x06037E8C RID: 229004 RVA: 0x00E2A4BC File Offset: 0x00E286BC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUISprite)),
				new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUITexture)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIText)),
				new ValueTuple<int, Type>(9, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(4, new Action(this.OnPhantomBtnClick))
			};
		}

		// Token: 0x06037E8D RID: 229005 RVA: 0x00E2A5D4 File Offset: 0x00E287D4
		private UniTask InitRoleHead()
		{
			PhantomArenaRoleItem.<InitRoleHead>d__9 <InitRoleHead>d__;
			<InitRoleHead>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitRoleHead>d__.<>4__this = this;
			<InitRoleHead>d__.<>1__state = -1;
			<InitRoleHead>d__.<>t__builder.Start<PhantomArenaRoleItem.<InitRoleHead>d__9>(ref <InitRoleHead>d__);
			return <InitRoleHead>d__.<>t__builder.Task;
		}

		// Token: 0x06037E8E RID: 229006 RVA: 0x00E2A618 File Offset: 0x00E28818
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaRoleItem.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaRoleItem.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037E8F RID: 229007 RVA: 0x00E2A65C File Offset: 0x00E2885C
		protected override void OnStart()
		{
			this.Sequence = new UiSequencePlayer(this.RootItem);
			this.ShieldSequence = new UiSequencePlayer(base.GetItem(7));
			this.ShieldSequence.BindOnEndSequenceEvent(new Action<string>(this.OnSequenceEndEvent));
			this.ViewProxy.BanButtonClickModule.RegisterButton(base.GetButton(4));
			base.GetItem(7).SetUIActive(false);
		}

		// Token: 0x06037E90 RID: 229008 RVA: 0x00E2A6C7 File Offset: 0x00E288C7
		protected override void OnBeforeDestroy()
		{
			this.Sequence.Clear();
			this.ShieldSequence.Clear();
		}

		// Token: 0x06037E91 RID: 229009 RVA: 0x00E2A6DF File Offset: 0x00E288DF
		private void OnSequenceEndEvent(string sequenceName)
		{
			if (sequenceName == "ShiedBreak")
			{
				base.GetItem(7).SetUIActive(false);
			}
		}

		// Token: 0x06037E92 RID: 229010 RVA: 0x00E2A6FB File Offset: 0x00E288FB
		private void OnPhantomBtnClick()
		{
			if (this.ViewProxy.InCantDragState())
			{
				return;
			}
			this.ViewProxy.SwitchFourCostTips(this.IsOwn, base.GetItem(5));
		}

		// Token: 0x06037E93 RID: 229011 RVA: 0x00E2A723 File Offset: 0x00E28923
		public void RefreshLifeNum(int lifeNum, int maxLifeNum)
		{
			this.LastLifeNum = lifeNum;
			base.GetText(2).SetText(lifeNum.ToString() + "/" + maxLifeNum.ToString(), true);
			this.RoleHead.RefreshLifeBar((float)lifeNum / (float)maxLifeNum);
		}

		// Token: 0x06037E94 RID: 229012 RVA: 0x00E2A764 File Offset: 0x00E28964
		public void RefreshLifeNumTween(float lifeNum, int maxLifeNum)
		{
			this.LastLifeNum = (int)lifeNum;
			base.GetText(2).SetText(Math.Floor((double)lifeNum).ToString() + "/" + maxLifeNum.ToString(), true);
			this.RoleHead.RefreshDamageBar(lifeNum / (float)maxLifeNum);
		}

		// Token: 0x06037E95 RID: 229013 RVA: 0x00E2A7B5 File Offset: 0x00E289B5
		public void RefreshLifeNumTweenStart(int lifeNum, int maxLifeNum)
		{
			this.RoleHead.RefreshLifeBar((float)lifeNum / (float)maxLifeNum);
		}

		// Token: 0x06037E96 RID: 229014 RVA: 0x00E2A7C7 File Offset: 0x00E289C7
		public void SetBarActive(bool isOwn)
		{
			this.RoleHead.SetBarActive(isOwn);
		}

		// Token: 0x06037E97 RID: 229015 RVA: 0x00E2A7D8 File Offset: 0x00E289D8
		public void SetPhantomBtnActive(bool isActive)
		{
			base.GetButton(4).RootUIComp.Get().SetUIActive(isActive);
		}

		// Token: 0x06037E98 RID: 229016 RVA: 0x00E2A7FF File Offset: 0x00E289FF
		public void ShowPhantomBtn()
		{
			this.SetPhantomBtnActive(true);
			this.Sequence.PlaySequencePurely("4cShow", false, false);
		}

		// Token: 0x06037E99 RID: 229017 RVA: 0x00E2A81A File Offset: 0x00E28A1A
		public void RefreshHeadIcon(string headIcon)
		{
			this.RoleHead.RefreshRoleIcon(headIcon);
		}

		// Token: 0x06037E9A RID: 229018 RVA: 0x00E2A828 File Offset: 0x00E28A28
		public void RefreshMonsterIcon(string path)
		{
			base.SetTextureByPath(path, base.GetTexture(6), null, null);
		}

		// Token: 0x06037E9B RID: 229019 RVA: 0x00E2A84D File Offset: 0x00E28A4D
		public void RegisterViewProxy(PhantomArenaBattleProxy viewProxy)
		{
			this.ViewProxy = viewProxy;
		}

		// Token: 0x06037E9C RID: 229020 RVA: 0x00E2A858 File Offset: 0x00E28A58
		public void PlayHpEffect(int lifeNum)
		{
			int num = lifeNum - this.LastLifeNum;
			if (num > 0)
			{
				this.RoleHead.PlayAddHpEffect(num).Forget();
				return;
			}
			if (num < 0)
			{
				this.RoleHead.PlayReduceHpEffect(num).Forget();
			}
		}

		// Token: 0x06037E9D RID: 229021 RVA: 0x00E2A899 File Offset: 0x00E28A99
		public void PlayHitAnim()
		{
			this.Sequence.PlaySequencePurely(EPhantomBattleHeadAnim.Hit.ToString(), false, false);
		}

		// Token: 0x06037E9E RID: 229022 RVA: 0x00E2A8B8 File Offset: 0x00E28AB8
		public void RefreshShieldNum(int shieldNum)
		{
			if (shieldNum > this.LastShieldNum && this.LastShieldNum == 0)
			{
				base.GetText(8).SetText(shieldNum.ToString(), true);
				this.ShieldSequence.PlaySequencePurely("ShieldStart", false, false);
				base.GetItem(7).SetUIActive(true);
				this.LastShieldNum = shieldNum;
				return;
			}
			if (shieldNum >= this.LastShieldNum)
			{
				base.GetText(8).SetText(shieldNum.ToString(), true);
				this.LastShieldNum = shieldNum;
				return;
			}
			if (shieldNum == 0)
			{
				this.ShieldSequence.PlaySequencePurely("ShiedBreak", false, false);
				this.LastShieldNum = shieldNum;
				return;
			}
			int num = shieldNum - this.LastShieldNum;
			base.GetText(8).SetText(shieldNum.ToString(), true);
			base.GetText(9).SetText(num.ToString(), true);
			this.ShieldSequence.PlaySequencePurely("ShieldHit", false, false);
			this.LastShieldNum = shieldNum;
		}

		// Token: 0x06037E9F RID: 229023 RVA: 0x00E2A9A0 File Offset: 0x00E28BA0
		public UniTask PlayBeHitEffect(int damage)
		{
			PhantomArenaRoleItem.<PlayBeHitEffect>d__27 <PlayBeHitEffect>d__;
			<PlayBeHitEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayBeHitEffect>d__.<>4__this = this;
			<PlayBeHitEffect>d__.damage = damage;
			<PlayBeHitEffect>d__.<>1__state = -1;
			<PlayBeHitEffect>d__.<>t__builder.Start<PhantomArenaRoleItem.<PlayBeHitEffect>d__27>(ref <PlayBeHitEffect>d__);
			return <PlayBeHitEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06037EA0 RID: 229024 RVA: 0x00E2A9EB File Offset: 0x00E28BEB
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams == null || configParams.Length == 0)
			{
				return null;
			}
			if (!(configParams[0] == "Task"))
			{
				return null;
			}
			PhantomArenaBattleProxy viewProxy = this.ViewProxy;
			if (viewProxy == null)
			{
				return null;
			}
			PhantomArenaBattleDetailsTips detailsTipsItem = viewProxy.DetailsTipsItem;
			if (detailsTipsItem == null)
			{
				return null;
			}
			return detailsTipsItem.GetGuideUiItemAndUiItemForShowEx(configParams);
		}

		// Token: 0x0401FFD5 RID: 131029
		protected PhantomArenaHeadItem RoleHead;

		// Token: 0x0401FFD6 RID: 131030
		protected PhantomArenaBattleProxy ViewProxy;

		// Token: 0x0401FFD7 RID: 131031
		protected UiSequencePlayer Sequence;

		// Token: 0x0401FFD8 RID: 131032
		protected UiSequencePlayer ShieldSequence;

		// Token: 0x0401FFD9 RID: 131033
		protected int LastLifeNum;

		// Token: 0x0401FFDA RID: 131034
		protected int LastShieldNum;

		// Token: 0x0401FFDB RID: 131035
		public bool IsOwn;

		// Token: 0x0200B59E RID: 46494
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403832B RID: 230187
			public const int HeadItem = 0;

			// Token: 0x0403832C RID: 230188
			public const int TaskNum = 1;

			// Token: 0x0403832D RID: 230189
			public const int LifeNum = 2;

			// Token: 0x0403832E RID: 230190
			public const int PhantomSprite = 3;

			// Token: 0x0403832F RID: 230191
			public const int PhantomBtn = 4;

			// Token: 0x04038330 RID: 230192
			public const int AttachItem = 5;

			// Token: 0x04038331 RID: 230193
			public const int MonsterTex = 6;

			// Token: 0x04038332 RID: 230194
			public const int ShieldItem = 7;

			// Token: 0x04038333 RID: 230195
			public const int ShieldNum = 8;

			// Token: 0x04038334 RID: 230196
			public const int ShieldReduceNum = 9;
		}
	}
}
