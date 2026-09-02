using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.MapRogue;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Google.Protobuf.Collections;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005262 RID: 21090
	public class RogueBattleLinkUnlockView : UiViewBase
	{
		// Token: 0x06035FAE RID: 221102 RVA: 0x00D9510B File Offset: 0x00D9330B
		[NullableContext(1)]
		public RogueBattleLinkUnlockView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06035FAF RID: 221103 RVA: 0x00D95114 File Offset: 0x00D93314
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUITexture)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(5, new Action(this.OnClickConfirm))
			};
		}

		// Token: 0x06035FB0 RID: 221104 RVA: 0x00D951D4 File Offset: 0x00D933D4
		protected override UniTask OnBeforeStartAsync()
		{
			RogueBattleLinkUnlockView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RogueBattleLinkUnlockView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035FB1 RID: 221105 RVA: 0x00D95217 File Offset: 0x00D93417
		protected override void OnBeforeHide()
		{
			if (this.UiViewSequence.HasSequenceNameInPlaying("Start"))
			{
				this.UiViewSequence.StopSequenceByKey("Start", false, true);
			}
		}

		// Token: 0x06035FB2 RID: 221106 RVA: 0x00D95240 File Offset: 0x00D93440
		protected void RefreshLinkInfo()
		{
			MapRogueOpRoleBuffBondLinkId mapRogueOpRoleBuffBondLinkId = (MapRogueOpRoleBuffBondLinkId)ModelBase<MapRogueModel>.Instance.GetOpData((int)this.OpenParam);
			if (mapRogueOpRoleBuffBondLinkId == null)
			{
				return;
			}
			RepeatedField<int> linkId = mapRogueOpRoleBuffBondLinkId.Data.RollBuffBondLinkIdOp.LinkId;
			if (linkId == null || this.CurrentIndex >= linkId.Count)
			{
				return;
			}
			int id = linkId[this.CurrentIndex];
			RogueResBond? rogueResBond = ConfigBase<RogueBattleConfig>.Instance.GetRogueResBond(id);
			if (rogueResBond == null)
			{
				return;
			}
			base.SetTextureShowUntilLoaded(rogueResBond.Value.Icon, base.GetTexture(3), null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), rogueResBond.Value.Name, Array.Empty<object>());
			RoleBondInfo roleBondDataById = ModelBase<RogueBattleModel>.Instance.GetRoleBondDataById(id);
			if (roleBondDataById == null)
			{
				return;
			}
			int level = roleBondDataById.Level;
			string linkEffectDesc = rogueResBond.Value.GetLinkEffectDesc(level);
			string linkEffectDescParam = rogueResBond.Value.GetLinkEffectDescParam(level);
			if (linkEffectDesc != null && linkEffectDescParam != null)
			{
				string[] args = linkEffectDescParam.Split('#', StringSplitOptions.None);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), linkEffectDesc, args);
			}
		}

		// Token: 0x06035FB3 RID: 221107 RVA: 0x00D95364 File Offset: 0x00D93564
		protected void OnClickConfirm()
		{
			MapRogueOpRoleBuffBondLinkId mapRogueOpRoleBuffBondLinkId = (MapRogueOpRoleBuffBondLinkId)ModelBase<MapRogueModel>.Instance.GetOpData((int)this.OpenParam);
			if (mapRogueOpRoleBuffBondLinkId == null)
			{
				return;
			}
			RepeatedField<int> linkId = mapRogueOpRoleBuffBondLinkId.Data.RollBuffBondLinkIdOp.LinkId;
			if (linkId == null || this.CurrentIndex >= linkId.Count - 1)
			{
				ModelBase<MapRogueModel>.Instance.ExecuteOpData((int)this.OpenParam, null);
				return;
			}
			this.CurrentIndex++;
			this.RefreshLinkInfo();
			if (this.UiViewSequence.HasSequenceNameInPlaying("Start"))
			{
				this.UiViewSequence.ReplaySequence("Start");
				return;
			}
			this.UiViewSequence.PlaySequence("Start", false, null);
		}

		// Token: 0x0401F023 RID: 127011
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x0401F024 RID: 127012
		private int CurrentIndex;
	}
}
