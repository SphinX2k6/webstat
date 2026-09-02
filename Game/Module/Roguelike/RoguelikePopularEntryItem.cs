using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005157 RID: 20823
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoguelikePopularEntryItem : GridProxyAbstract<RoguelikeEntryData>
	{
		// Token: 0x06035997 RID: 219543 RVA: 0x00D76914 File Offset: 0x00D74B14
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
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			if (this.IsValid)
			{
				num2 = 1;
				List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
				CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
				Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
				num = 0;
				*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickSelf));
				this.BtnBindInfo = list2;
			}
		}

		// Token: 0x06035998 RID: 219544 RVA: 0x00D76A46 File Offset: 0x00D74C46
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			base.GetItem(4).SetUIActive(true);
			this.Vm = ModelBase<RoguelikeModel>.Instance.GetEntranceViewModel();
		}

		// Token: 0x06035999 RID: 219545 RVA: 0x00D76A78 File Offset: 0x00D74C78
		[NullableContext(1)]
		public override void Refresh(RoguelikeEntryData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			data.SetEntryToggleState = new Action<bool, bool>(this.SetToggleState);
			string icon = data.GetConfig().Icon;
			bool flag = icon.Contains("Atlas");
			UUITexture texture = base.GetTexture(2);
			texture.SetUIActive(!flag);
			UUISprite sprite = base.GetSprite(3);
			sprite.SetUIActive(flag);
			if (flag)
			{
				this.SetSpriteByPath(icon, sprite, false, null, null);
			}
			else
			{
				base.SetTextureByPath(icon, texture, null, null);
			}
			bool entryDataActiveState = this.Vm.GetEntryDataActiveState(data);
			bool isUnlock = this.Vm.EntriesDataGroupMap[data.GroupId].IsUnlock;
			FColor color = FColor.FromHex(ConfigBase<RoguelikeConfig>.Instance.GetRogueHotEntryTypeConfig((int)data.Type).Value.ArrowColor);
			base.GetTexture(1).SetColor(color);
			base.GetItem(5).SetUIActive(!isUnlock);
			this.SetActiveState(entryDataActiveState);
		}

		// Token: 0x0603599A RID: 219546 RVA: 0x00D76B84 File Offset: 0x00D74D84
		protected override void OnBeforeDestroy()
		{
			if (this.Data != null)
			{
				this.Data.SetEntryToggleState = null;
			}
		}

		// Token: 0x0603599B RID: 219547 RVA: 0x00D76B9A File Offset: 0x00D74D9A
		private void OnClickSelf(EToggleState state)
		{
			RoguelikeEntranceViewModel vm = this.Vm;
			if (vm == null)
			{
				return;
			}
			Action<bool, RoguelikeEntryData> onClickEntry = vm.OnClickEntry;
			if (onClickEntry == null)
			{
				return;
			}
			onClickEntry(state == EToggleState.ETT_Checked, this.Data);
		}

		// Token: 0x0603599C RID: 219548 RVA: 0x00D76BC0 File Offset: 0x00D74DC0
		public void SetEmpty()
		{
			base.GetExtendToggle(0).RootUIComp.Get().SetUIActive(false);
			base.SetUiActive(true);
		}

		// Token: 0x0603599D RID: 219549 RVA: 0x00D76BF0 File Offset: 0x00D74DF0
		public void SetActiveState(bool isActive)
		{
			this.LevelSequencePlayer.StopPlayingSequence(false, true);
			this.LevelSequencePlayer.PlayOrReplaySequenceByName(isActive ? "True" : "False", false, null);
		}

		// Token: 0x0603599E RID: 219550 RVA: 0x00D76C2E File Offset: 0x00D74E2E
		public void SetFocusState(bool isFocus)
		{
		}

		// Token: 0x0603599F RID: 219551 RVA: 0x00D76C30 File Offset: 0x00D74E30
		private void SetToggleState(bool isSelected, bool bFireEvent)
		{
			base.GetExtendToggle(0).SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, bFireEvent, false, false);
		}

		// Token: 0x0401EC9C RID: 126108
		private RoguelikeEntranceViewModel Vm;

		// Token: 0x0401EC9D RID: 126109
		private RoguelikeEntryData Data;

		// Token: 0x0401EC9E RID: 126110
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0401EC9F RID: 126111
		public bool IsValid = true;

		// Token: 0x0200B104 RID: 45316
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x04036E8E RID: 224910
			public const int ToggleSelf = 0;

			// Token: 0x04036E8F RID: 224911
			public const int TexArrow = 1;

			// Token: 0x04036E90 RID: 224912
			public const int TexIcon = 2;

			// Token: 0x04036E91 RID: 224913
			public const int SpriteIcon = 3;

			// Token: 0x04036E92 RID: 224914
			public const int ItemActive = 4;

			// Token: 0x04036E93 RID: 224915
			public const int ItemLock = 5;
		}
	}
}
