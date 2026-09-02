using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Morale.Data;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Morale
{
	// Token: 0x020056FD RID: 22269
	[NullableContext(1)]
	[Nullable(0)]
	public class MoraleAreaInfoFlagItem : UiPanelBase
	{
		// Token: 0x06038AB0 RID: 232112 RVA: 0x00E597AC File Offset: 0x00E579AC
		public UniTask Init(string path, UUIItem parentItem, MoraleAreaFlagData flagData)
		{
			MoraleAreaInfoFlagItem.<Init>d__4 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.path = path;
			<Init>d__.parentItem = parentItem;
			<Init>d__.flagData = flagData;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<MoraleAreaInfoFlagItem.<Init>d__4>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06038AB1 RID: 232113 RVA: 0x00E59808 File Offset: 0x00E57A08
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnBtnSelf));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06038AB2 RID: 232114 RVA: 0x00E59932 File Offset: 0x00E57B32
		protected override void OnStart()
		{
			UUIText text = base.GetText(2);
			if (text == null)
			{
				return;
			}
			text.ShowTextNew(this.FlagData.Config.Index);
		}

		// Token: 0x06038AB3 RID: 232115 RVA: 0x00E59955 File Offset: 0x00E57B55
		[Conditional("WITH_EDITOR")]
		private void EditorShowFlagInfo()
		{
		}

		// Token: 0x06038AB4 RID: 232116 RVA: 0x00E59957 File Offset: 0x00E57B57
		private void OnBtnSelf(EToggleState toggleState)
		{
			Action<MoraleAreaFlagData> clickCallback = this.ClickCallback;
			if (clickCallback == null)
			{
				return;
			}
			clickCallback(this.FlagData);
		}

		// Token: 0x06038AB5 RID: 232117 RVA: 0x00E59970 File Offset: 0x00E57B70
		public void UpdateData()
		{
			this.UpdateSelectState();
			bool uiactive = this.FlagData.HasBoxCanGet();
			UUIItem item = base.GetItem(5);
			if (item != null)
			{
				item.SetUIActive(uiactive);
			}
			bool isActive = this.FlagData.IsActive;
			string[] array = this.FlagData.TypeConfig.Value.IconPathNormal();
			string[] array2 = this.FlagData.TypeConfig.Value.IconPathActive();
			UUITexture texture = base.GetTexture(1);
			base.SetTextureByPath(isActive ? array2[0] : array[0], texture, null, null);
			UUISprite sprite = base.GetSprite(4);
			this.SetSpriteByPath(isActive ? array2[1] : array[1], sprite, false, null, null);
		}

		// Token: 0x06038AB6 RID: 232118 RVA: 0x00E59A34 File Offset: 0x00E57C34
		public void UpdatePosition(UUIItem item)
		{
			FVector uiworldPosition = item.GetUIWorldPosition();
			UUIItem rootItem = this.RootItem;
			if (rootItem == null)
			{
				return;
			}
			rootItem.SetUIWorldLocation(uiworldPosition);
		}

		// Token: 0x06038AB7 RID: 232119 RVA: 0x00E59A5C File Offset: 0x00E57C5C
		public void UpdateSelectState()
		{
			EToggleState state = this.FlagData.IsSelect ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleStateForce(state, false, false, false);
		}

		// Token: 0x06038AB8 RID: 232120 RVA: 0x00E59A90 File Offset: 0x00E57C90
		public void PlayStartSequence()
		{
			LevelSequencePlayer sequence = this.Sequence;
			if (sequence != null)
			{
				sequence.PlaySequencePurely("Start", false, false, null, null, false);
			}
			if (this.FlagData.IsSelect)
			{
				LevelSequencePlayer sequence2 = this.Sequence;
				if (sequence2 == null)
				{
					return;
				}
				sequence2.PlaySequencePurely("Select", false, false, null, null, false);
			}
		}

		// Token: 0x040204F7 RID: 132343
		public MoraleAreaFlagData FlagData;

		// Token: 0x040204F8 RID: 132344
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<MoraleAreaFlagData> ClickCallback;

		// Token: 0x040204F9 RID: 132345
		[Nullable(2)]
		public LevelSequencePlayer Sequence;

		// Token: 0x0200B770 RID: 46960
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x04038BC2 RID: 232386
			ToggleSelf,
			// Token: 0x04038BC3 RID: 232387
			TextureIcon,
			// Token: 0x04038BC4 RID: 232388
			TxtTitle,
			// Token: 0x04038BC5 RID: 232389
			ItemSelect,
			// Token: 0x04038BC6 RID: 232390
			SpriteTitleBg,
			// Token: 0x04038BC7 RID: 232391
			ItemBoxShow
		}
	}
}
