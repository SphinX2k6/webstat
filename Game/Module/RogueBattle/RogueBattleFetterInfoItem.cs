using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.MapRogue;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x020051CF RID: 20943
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RogueBattleFetterInfoItem : GridProxyAbstract<IRogueBattleRoleBondInfo>
	{
		// Token: 0x06035D18 RID: 220440 RVA: 0x00D8A334 File Offset: 0x00D88534
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUISprite)),
				new ValueTuple<int, Type>(5, typeof(UUISprite)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUITexture)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(10, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(9, new Action(this.OnClicked))
			};
		}

		// Token: 0x06035D19 RID: 220441 RVA: 0x00D8A464 File Offset: 0x00D88664
		[NullableContext(1)]
		public override void Refresh(IRogueBattleRoleBondInfo data, bool isSelected, int gridIndex)
		{
			RoleBondInfo roleBondDataById = ModelBase<RogueBattleModel>.Instance.GetRoleBondDataById(data.Id);
			this.Data = data;
			if (roleBondDataById == null)
			{
				return;
			}
			bool uiactive = data.AddStar + roleBondDataById.CurStar >= roleBondDataById.TargetStar && roleBondDataById.TargetStar != 0;
			base.GetItem(8).SetUIActive(uiactive);
			base.GetItem(10).SetUIActive(uiactive);
			UUIText text = base.GetText(1);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(roleBondDataById.Level + 1);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			if (roleBondDataById.TargetStar == 0)
			{
				base.GetSprite(4).SetFillAmount(1f);
				base.GetSprite(5).SetFillAmount(1f);
				this.TargetFillAmount = 1f;
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "RogueBattleFetterUpItem_ExpMaxLevel", Array.Empty<object>());
				UUIText text2 = base.GetText(3);
				if (text2 != null)
				{
					text2.SetUIActive(false);
				}
			}
			else
			{
				base.GetSprite(4).SetFillAmount((float)roleBondDataById.CurStar / (float)roleBondDataById.TargetStar);
				base.GetSprite(5).SetFillAmount((float)roleBondDataById.CurStar / (float)roleBondDataById.TargetStar);
				this.TargetFillAmount = (float)(roleBondDataById.CurStar + data.AddStar) / (float)roleBondDataById.TargetStar;
				UUIText text3 = base.GetText(3);
				if (text3 != null)
				{
					text3.SetUIActive(true);
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "RogueBattle_FetterInfo_Exp", new <>z__ReadOnlyArray<object>(new object[]
				{
					(roleBondDataById.CurStar + data.AddStar).ToString(),
					roleBondDataById.TargetStar.ToString()
				}));
				this.PlayExpChangeAnim();
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "RogueRes_FightFormation_RoleLevel", new <>z__ReadOnlySingleElementList<object>(roleBondDataById.Level));
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "RogueBattle_FetterInfo_Exp_AddLevel", new <>z__ReadOnlySingleElementList<object>(data.AddStar.ToString()));
			RogueResBond? rogueResBond = ConfigBase<RogueBattleConfig>.Instance.GetRogueResBond(data.Id);
			if (rogueResBond != null)
			{
				base.SetTextureShowUntilLoaded(rogueResBond.Value.Icon, base.GetTexture(7), null);
			}
		}

		// Token: 0x06035D1A RID: 220442 RVA: 0x00D8A6A0 File Offset: 0x00D888A0
		protected override void OnBeforeHide()
		{
			this.RemoveAnim();
		}

		// Token: 0x06035D1B RID: 220443 RVA: 0x00D8A6A8 File Offset: 0x00D888A8
		public void PlayExpChangeAnim()
		{
			this.RemoveAnim();
			float fillAmount = base.GetSprite(5).GetFillAmount();
			float animSpeed = Math.Abs(this.TargetFillAmount - fillAmount) / 200f;
			this.AnimationTimer = TimerSystem.GameplayTimeInstance.Forever(delegate(float delta)
			{
				float fillAmount2 = this.GetSprite(5).GetFillAmount();
				if (Math.Abs(fillAmount2 - this.TargetFillAmount) < 0.01f)
				{
					this.RemoveAnim();
					return;
				}
				float fillAmount3 = fillAmount2 + animSpeed * delta;
				this.GetSprite(5).SetFillAmount(fillAmount3);
			}, 20f, 1f, null, null, true);
		}

		// Token: 0x06035D1C RID: 220444 RVA: 0x00D8A718 File Offset: 0x00D88918
		private void RemoveAnim()
		{
			if (this.AnimationTimer != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.AnimationTimer);
				this.AnimationTimer = null;
			}
		}

		// Token: 0x06035D1D RID: 220445 RVA: 0x00D8A73C File Offset: 0x00D8893C
		private void OnClicked()
		{
			MapRogueController instance = ControllerBase<MapRogueController>.Instance;
			IRogueBattleRoleBondInfo data = this.Data;
			instance.OpenRogueFetterView((data != null) ? new int?(data.Id) : null);
		}

		// Token: 0x0401EE13 RID: 126483
		private TimerHandle AnimationTimer;

		// Token: 0x0401EE14 RID: 126484
		private IRogueBattleRoleBondInfo Data;

		// Token: 0x0401EE15 RID: 126485
		private float TargetFillAmount;
	}
}
