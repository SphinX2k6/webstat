using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EBA RID: 24250
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CiacconaGalStepChoiceItem : GridProxyAbstract<CiacconaGalChoiceData>
	{
		// Token: 0x0603CF40 RID: 249664 RVA: 0x00F7AEA8 File Offset: 0x00F790A8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIExtendToggleTextureTransition));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleClicked));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603CF41 RID: 249665 RVA: 0x00F7AF6F File Offset: 0x00F7916F
		protected override void OnStart()
		{
			this.Toggle = base.GetExtendToggle(0);
			this.SeqPlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x0603CF42 RID: 249666 RVA: 0x00F7AF90 File Offset: 0x00F79190
		protected override void OnAfterShow()
		{
			LevelSequencePlayer seqPlayer = this.SeqPlayer;
			if (seqPlayer == null)
			{
				return;
			}
			seqPlayer.PlayLevelSequenceByName("Start", false, null, false);
		}

		// Token: 0x0603CF43 RID: 249667 RVA: 0x00F7AFBD File Offset: 0x00F791BD
		[NullableContext(1)]
		public override void Refresh(CiacconaGalChoiceData data, bool isSelected, int gridIndex)
		{
			this.ChoiceData = data;
			this.RefreshContent();
			this.RefreshState();
		}

		// Token: 0x0603CF44 RID: 249668 RVA: 0x00F7AFD2 File Offset: 0x00F791D2
		private void RefreshContent()
		{
			if (this.ChoiceData == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), this.ChoiceData.Content, Array.Empty<object>());
		}

		// Token: 0x0603CF45 RID: 249669 RVA: 0x00F7B000 File Offset: 0x00F79200
		private void RefreshState()
		{
			if (this.ChoiceData == null)
			{
				return;
			}
			UUIExtendToggle toggle = this.Toggle;
			if (toggle != null)
			{
				toggle.OnPointUpCallBack.Unbind();
			}
			switch (this.ChoiceData.State)
			{
			case ECiacconaGalStepState.Normal:
			{
				if (this.LastState == ECiacconaGalStepState.LockingByInspiration)
				{
					LevelSequencePlayer seqPlayer = this.SeqPlayer;
					if (seqPlayer != null)
					{
						seqPlayer.PlayLevelSequenceByName("Use", false, null, false);
					}
				}
				this.UpdateIcon("T_PlotReasoningIcon04");
				UUIExtendToggle toggle2 = this.Toggle;
				if (toggle2 != null)
				{
					toggle2.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
				}
				break;
			}
			case ECiacconaGalStepState.LockingByInspiration:
			{
				this.UpdateIcon("T_PlotReasoningIcon02");
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "Xkjsx_Inspiration_Unlockcondition", new int[]
				{
					this.ChoiceData.RequiredInspiration
				});
				UUIExtendToggle toggle3 = this.Toggle;
				if (toggle3 != null)
				{
					toggle3.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
				}
				break;
			}
			case ECiacconaGalStepState.LockingByCondition:
			{
				this.UpdateIcon("T_PlotReasoningIcon01");
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), this.ChoiceData.Content, Array.Empty<object>());
				UUIExtendToggle toggle4 = this.Toggle;
				if (toggle4 != null)
				{
					toggle4.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
				}
				break;
			}
			case ECiacconaGalStepState.Chosen:
			{
				this.UpdateIcon("T_PlotReasoningIcon03");
				UUIExtendToggle toggle5 = this.Toggle;
				if (toggle5 != null)
				{
					toggle5.SetToggleState(EToggleState.ETT_UnDetermined, false, false, false);
				}
				UUIExtendToggle toggle6 = this.Toggle;
				if (toggle6 != null)
				{
					toggle6.OnPointUpCallBack.Bind(new Action<EToggleState>(this.OnToggleClicked));
				}
				break;
			}
			}
			this.LastState = this.ChoiceData.State;
		}

		// Token: 0x0603CF46 RID: 249670 RVA: 0x00F7B198 File Offset: 0x00F79398
		[NullableContext(1)]
		private UniTask UpdateIcon(string resourceName)
		{
			CiacconaGalStepChoiceItem.<UpdateIcon>d__11 <UpdateIcon>d__;
			<UpdateIcon>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<UpdateIcon>d__.<>4__this = this;
			<UpdateIcon>d__.resourceName = resourceName;
			<UpdateIcon>d__.<>1__state = -1;
			<UpdateIcon>d__.<>t__builder.Start<CiacconaGalStepChoiceItem.<UpdateIcon>d__11>(ref <UpdateIcon>d__);
			return <UpdateIcon>d__.<>t__builder.Task;
		}

		// Token: 0x0603CF47 RID: 249671 RVA: 0x00F7B1E3 File Offset: 0x00F793E3
		private void OnToggleClicked(EToggleState state)
		{
			ControllerBase<CiacconaGalController>.Instance.GalPlayer.OnClick(new int?(this.ChoiceData.Id));
		}

		// Token: 0x04022370 RID: 140144
		private CiacconaGalChoiceData ChoiceData;

		// Token: 0x04022371 RID: 140145
		private ECiacconaGalStepState LastState;

		// Token: 0x04022372 RID: 140146
		private UUIExtendToggle Toggle;

		// Token: 0x04022373 RID: 140147
		private LevelSequencePlayer SeqPlayer;

		// Token: 0x0200BEA9 RID: 48809
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403AB18 RID: 240408
			public const int Toggle = 0;

			// Token: 0x0403AB19 RID: 240409
			public const int TextContent = 1;

			// Token: 0x0403AB1A RID: 240410
			public const int ImageIcon = 2;
		}
	}
}
