using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Sheriff.View.Item
{
	// Token: 0x02004FE3 RID: 20451
	[NullableContext(1)]
	[Nullable(0)]
	public class SheriffMainAnalysisClueDialogPanel : UiPanelBase
	{
		// Token: 0x06034BB2 RID: 215986 RVA: 0x00D3A598 File Offset: 0x00D38798
		public SheriffMainAnalysisClueDialogPanel(SheriffMainProxy proxy)
		{
			this.Proxy = proxy;
		}

		// Token: 0x06034BB3 RID: 215987 RVA: 0x00D3A5A8 File Offset: 0x00D387A8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickBtnLeft));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickBtnNextPage));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06034BB4 RID: 215988 RVA: 0x00D3A75C File Offset: 0x00D3895C
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.NextBtn = new ButtonItem(base.GetItem(7));
			this.NextBtn.SetFunction(new Action<int>(this.OnClickBtnRight));
			EPlayerGender playerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
			if (playerGender == EPlayerGender.None)
			{
				return;
			}
			string resourceId = (playerGender == EPlayerGender.Male) ? "T_SkyEyeRoleMale" : "T_SkyEyeRoleFemale";
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			base.SetTextureByPath(resourcePath, base.GetTexture(0), null, null);
		}

		// Token: 0x06034BB5 RID: 215989 RVA: 0x00D3A7E8 File Offset: 0x00D389E8
		public void RefreshTitleText(string text)
		{
			base.GetText(3).ShowTextNew(text);
		}

		// Token: 0x06034BB6 RID: 215990 RVA: 0x00D3A7F7 File Offset: 0x00D389F7
		public void RefreshDialogText(string text)
		{
			base.GetText(4).ShowTextNew(text);
		}

		// Token: 0x06034BB7 RID: 215991 RVA: 0x00D3A808 File Offset: 0x00D38A08
		public void RefreshDialogPanel(EClueState state)
		{
			base.GetSprite(8).SetUIActive(state == EClueState.Success);
			base.GetItem(2).SetUIActive(state != EClueState.Success);
			base.GetItem(5).SetUIActive(state != EClueState.Success);
			UUIButtonComponent button = base.GetButton(1);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(state == EClueState.Success);
			}
			ButtonItem nextBtn = this.NextBtn;
			if (nextBtn != null)
			{
				nextBtn.SetUiActive(state == EClueState.Conclusion);
			}
			UUIButtonComponent button2 = base.GetButton(6);
			if (button2 != null)
			{
				button2.RootUIComp.Get().SetUIActive(state == EClueState.Fail);
			}
			if (state == EClueState.Conclusion)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.SheriffAnalysisResultPop, true, null);
				return;
			}
			this.LevelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		}

		// Token: 0x06034BB8 RID: 215992 RVA: 0x00D3A8DC File Offset: 0x00D38ADC
		public void RefreshNextBtnText(bool isEnding)
		{
			string textId = isEnding ? "Inference_Desc_21" : "Inference_Desc_12";
			this.NextBtn.SetLocalTextNew(textId, Array.Empty<object>());
		}

		// Token: 0x06034BB9 RID: 215993 RVA: 0x00D3A90A File Offset: 0x00D38B0A
		public void SetNextQuestionIdOrEnding(ISheriffQuestionResultJsonConfig config)
		{
			this.QuestionConfig = config;
		}

		// Token: 0x06034BBA RID: 215994 RVA: 0x00D3A913 File Offset: 0x00D38B13
		private void OnClickBtnLeft()
		{
			this.Proxy.DoAfterAnalysisClueLogic(true, null);
		}

		// Token: 0x06034BBB RID: 215995 RVA: 0x00D3A922 File Offset: 0x00D38B22
		private void OnClickBtnRight(int data)
		{
			this.Proxy.DoAfterAnalysisClueLogic(false, this.QuestionConfig);
		}

		// Token: 0x06034BBC RID: 215996 RVA: 0x00D3A936 File Offset: 0x00D38B36
		private void OnClickBtnNextPage()
		{
			Action refreshDialogCallback = this.RefreshDialogCallback;
			if (refreshDialogCallback == null)
			{
				return;
			}
			refreshDialogCallback();
		}

		// Token: 0x0401E62C RID: 124460
		protected SheriffMainProxy Proxy;

		// Token: 0x0401E62D RID: 124461
		[Nullable(2)]
		public Action RefreshDialogCallback;

		// Token: 0x0401E62E RID: 124462
		[Nullable(2)]
		protected ButtonItem NextBtn;

		// Token: 0x0401E62F RID: 124463
		[Nullable(2)]
		protected ISheriffQuestionResultJsonConfig QuestionConfig;

		// Token: 0x0401E630 RID: 124464
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200AFBE RID: 44990
		[NullableContext(0)]
		private static class EDialogDefine
		{
			// Token: 0x04036881 RID: 223361
			public const int TexRole = 0;

			// Token: 0x04036882 RID: 223362
			public const int BtnNextPage = 1;

			// Token: 0x04036883 RID: 223363
			public const int PanelTitle = 2;

			// Token: 0x04036884 RID: 223364
			public const int TxtTitle = 3;

			// Token: 0x04036885 RID: 223365
			public const int TxtList = 4;

			// Token: 0x04036886 RID: 223366
			public const int PanelBtn = 5;

			// Token: 0x04036887 RID: 223367
			public const int BtnLeft = 6;

			// Token: 0x04036888 RID: 223368
			public const int BtnRight = 7;

			// Token: 0x04036889 RID: 223369
			public const int SpriteArrow = 8;
		}
	}
}
