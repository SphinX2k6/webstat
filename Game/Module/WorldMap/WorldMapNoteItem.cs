using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap
{
	// Token: 0x02004B44 RID: 19268
	public class WorldMapNoteItem : UiPanelBase
	{
		// Token: 0x0603244A RID: 205898 RVA: 0x00C910CA File Offset: 0x00C8F2CA
		[NullableContext(1)]
		public WorldMapNoteItem(UUIItem item)
		{
			item.SetUIActive(true);
			base.CreateThenShowByActor(item.GetOwner(), null);
		}

		// Token: 0x0603244B RID: 205899 RVA: 0x00C910E8 File Offset: 0x00C8F2E8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603244C RID: 205900 RVA: 0x00C91233 File Offset: 0x00C8F433
		protected override void OnStart()
		{
		}

		// Token: 0x0603244D RID: 205901 RVA: 0x00C91235 File Offset: 0x00C8F435
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer sequence = this.Sequence;
			if (sequence != null)
			{
				sequence.Clear();
			}
			this.Sequence = null;
		}

		// Token: 0x0603244E RID: 205902 RVA: 0x00C91250 File Offset: 0x00C8F450
		[NullableContext(1)]
		public void UpdateNoteItem(int mapNoteId, Action<int> callback, int? mapMarkId = null, [Nullable(2)] string customDesc = null)
		{
			UUISprite sprite = base.GetSprite(0);
			MapNote? config = ConfigMapNoteById.GetConfig(mapNoteId, true);
			this.SetSpriteByPath(config.Value.Icon, sprite, true, null, null);
			UUIText text = base.GetText(1);
			if (customDesc != null)
			{
				text.SetText(customDesc, true);
			}
			else
			{
				text.ShowTextNew(config.Value.Desc);
			}
			int style = config.Value.Style;
			base.GetItem(3).SetUIActive(style == WorldMapNoteItem.EMapNoteStyle.Normal);
			base.GetItem(6).SetUIActive(style == WorldMapNoteItem.EMapNoteStyle.Normal);
			base.GetItem(4).SetUIActive(style == WorldMapNoteItem.EMapNoteStyle.Available);
			base.GetItem(5).SetUIActive(style == WorldMapNoteItem.EMapNoteStyle.Available);
			this.MarkId = mapMarkId.GetValueOrDefault();
			this.ClickCallback = callback;
		}

		// Token: 0x0603244F RID: 205903 RVA: 0x00C91332 File Offset: 0x00C8F532
		private void OnClick()
		{
			Action<int> clickCallback = this.ClickCallback;
			if (clickCallback == null)
			{
				return;
			}
			clickCallback(this.MarkId);
		}

		// Token: 0x06032450 RID: 205904 RVA: 0x00C9134C File Offset: 0x00C8F54C
		public void PlayStartToPause()
		{
			if (this.Sequence == null)
			{
				this.Sequence = new LevelSequencePlayer(this.RootItem);
			}
			this.Sequence.PlayLevelSequenceByName("Start", false, null, false);
			this.Sequence.PauseSequence();
			UUIItem rootItem = this.RootItem;
			if (rootItem == null)
			{
				return;
			}
			rootItem.SetUIActive(false);
		}

		// Token: 0x06032451 RID: 205905 RVA: 0x00C913AC File Offset: 0x00C8F5AC
		public UniTask ResumeSequence(int index)
		{
			WorldMapNoteItem.<ResumeSequence>d__12 <ResumeSequence>d__;
			<ResumeSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ResumeSequence>d__.<>4__this = this;
			<ResumeSequence>d__.index = index;
			<ResumeSequence>d__.<>1__state = -1;
			<ResumeSequence>d__.<>t__builder.Start<WorldMapNoteItem.<ResumeSequence>d__12>(ref <ResumeSequence>d__);
			return <ResumeSequence>d__.<>t__builder.Task;
		}

		// Token: 0x0401D62F RID: 120367
		private int MarkId;

		// Token: 0x0401D630 RID: 120368
		[Nullable(2)]
		private Action<int> ClickCallback;

		// Token: 0x0401D631 RID: 120369
		[Nullable(2)]
		private LevelSequencePlayer Sequence;

		// Token: 0x0200ABE5 RID: 44005
		public static class EChildComponents
		{
			// Token: 0x04035778 RID: 219000
			public const int NoteIcon = 0;

			// Token: 0x04035779 RID: 219001
			public const int NoteDesc = 1;

			// Token: 0x0403577A RID: 219002
			public const int NoteButton = 2;

			// Token: 0x0403577B RID: 219003
			public const int TexBg = 3;

			// Token: 0x0403577C RID: 219004
			public const int TexReceivedBg = 4;

			// Token: 0x0403577D RID: 219005
			public const int NiaAvailable = 5;

			// Token: 0x0403577E RID: 219006
			public const int NiaUnAvailable = 6;
		}

		// Token: 0x0200ABE6 RID: 44006
		public static class EMapNoteStyle
		{
			// Token: 0x0403577F RID: 219007
			public static readonly int Normal = 0;

			// Token: 0x04035780 RID: 219008
			public static readonly int Available = 1;
		}
	}
}
