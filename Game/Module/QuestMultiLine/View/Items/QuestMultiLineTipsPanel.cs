using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.QuestMultiLine.QuestMultiLineData;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuestMultiLine.View.Items
{
	// Token: 0x02005342 RID: 21314
	[NullableContext(2)]
	[Nullable(0)]
	public class QuestMultiLineTipsPanel : UiPanelBase
	{
		// Token: 0x060365CF RID: 222671 RVA: 0x00DB4C90 File Offset: 0x00DB2E90
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUISprite)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(7, typeof(UUITexture)),
				new ValueTuple<int, Type>(8, typeof(UUISprite)),
				new ValueTuple<int, Type>(9, typeof(UUITexture))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(6, new Action(this.HideSelf))
			};
		}

		// Token: 0x060365D0 RID: 222672 RVA: 0x00DB4DA8 File Offset: 0x00DB2FA8
		protected override void OnStart()
		{
			this.SequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		}

		// Token: 0x060365D1 RID: 222673 RVA: 0x00DB4DBB File Offset: 0x00DB2FBB
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.Clear();
			}
			this.SequencePlayer = null;
		}

		// Token: 0x060365D2 RID: 222674 RVA: 0x00DB4DD8 File Offset: 0x00DB2FD8
		[NullableContext(1)]
		public void RefreshTips(QuestMultiLineComponentData componentData)
		{
			this.ComponentData = componentData;
			bool flag = QuestMultiLineUtils.IsMultiPersonAvatar(this.ComponentData);
			base.GetTexture(0).SetUIActive(!flag);
			base.GetTexture(9).SetUIActive(flag);
			if (flag)
			{
				base.SetTextureByPath(QuestMultiLineUtils.GetMultiPersonAvatarTexture(this.ComponentData), base.GetTexture(9), null, null);
			}
			else
			{
				base.SetTextureByPath(QuestMultiLineUtils.GetComponentIconTexture(this.ComponentData), base.GetTexture(0), null, null);
			}
			string headIconBgInTip = this.ComponentData.HeadIconBgInTip;
			if (!string.IsNullOrEmpty(headIconBgInTip))
			{
				base.GetSprite(8).SetUIActive(true);
				this.SetSpriteByPath(headIconBgInTip, base.GetSprite(8), false, null, null);
			}
			else
			{
				base.GetSprite(8).SetUIActive(false);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), this.ComponentData.TipsTitle, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), this.ComponentData.TipsArea, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), this.ComponentData.TipsStatusDesc, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), this.ComponentData.TipsDesc, Array.Empty<object>());
			string statusIcon = QuestMultiLineConfig.GetComponentStatusConfigById(this.ComponentData.StatusType).Value.StatusIcon;
			if (!string.IsNullOrEmpty(statusIcon))
			{
				base.GetSprite(3).SetUIActive(true);
				this.SetSpriteByPath(statusIcon, base.GetSprite(3), false, null, null);
				return;
			}
			base.GetSprite(3).SetUIActive(false);
		}

		// Token: 0x060365D3 RID: 222675 RVA: 0x00DB4F8C File Offset: 0x00DB318C
		public void SetHideCallback(Action callback)
		{
			this.HideCallback = callback;
		}

		// Token: 0x060365D4 RID: 222676 RVA: 0x00DB4F95 File Offset: 0x00DB3195
		public void SetHideSelfBtnInterceptor(Func<bool> interceptor)
		{
			this.HideSelfBtnInterceptor = interceptor;
		}

		// Token: 0x060365D5 RID: 222677 RVA: 0x00DB4FA0 File Offset: 0x00DB31A0
		public UniTask ShowAndPlayStartAsync()
		{
			QuestMultiLineTipsPanel.<ShowAndPlayStartAsync>d__10 <ShowAndPlayStartAsync>d__;
			<ShowAndPlayStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ShowAndPlayStartAsync>d__.<>4__this = this;
			<ShowAndPlayStartAsync>d__.<>1__state = -1;
			<ShowAndPlayStartAsync>d__.<>t__builder.Start<QuestMultiLineTipsPanel.<ShowAndPlayStartAsync>d__10>(ref <ShowAndPlayStartAsync>d__);
			return <ShowAndPlayStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060365D6 RID: 222678 RVA: 0x00DB4FE4 File Offset: 0x00DB31E4
		public UniTask PlayCloseAndHideAsync()
		{
			QuestMultiLineTipsPanel.<PlayCloseAndHideAsync>d__11 <PlayCloseAndHideAsync>d__;
			<PlayCloseAndHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayCloseAndHideAsync>d__.<>4__this = this;
			<PlayCloseAndHideAsync>d__.<>1__state = -1;
			<PlayCloseAndHideAsync>d__.<>t__builder.Start<QuestMultiLineTipsPanel.<PlayCloseAndHideAsync>d__11>(ref <PlayCloseAndHideAsync>d__);
			return <PlayCloseAndHideAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060365D7 RID: 222679 RVA: 0x00DB5027 File Offset: 0x00DB3227
		private void HideSelf()
		{
			Func<bool> hideSelfBtnInterceptor = this.HideSelfBtnInterceptor;
			if (hideSelfBtnInterceptor != null && hideSelfBtnInterceptor())
			{
				return;
			}
			this.PlayCloseAndHideAsync();
			Singleton<AudioSystem>.Instance.PostEvent("play_ui_ia_com_close");
		}

		// Token: 0x0401F44E RID: 128078
		private QuestMultiLineComponentData ComponentData;

		// Token: 0x0401F44F RID: 128079
		private Action HideCallback;

		// Token: 0x0401F450 RID: 128080
		private Func<bool> HideSelfBtnInterceptor;

		// Token: 0x0401F451 RID: 128081
		private LevelSequencePlayer SequencePlayer;
	}
}
