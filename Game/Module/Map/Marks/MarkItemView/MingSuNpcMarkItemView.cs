using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Map.Marks.MarkItemView.Handles;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView
{
	// Token: 0x0200587A RID: 22650
	[NullableContext(1)]
	[Nullable(0)]
	public class MingSuNpcMarkItemView : ConfigMarkItemView
	{
		// Token: 0x0603998A RID: 235914 RVA: 0x00E9C71F File Offset: 0x00E9A91F
		public MingSuNpcMarkItemView(MingSuNpcMarkItem holder) : base(holder)
		{
		}

		// Token: 0x0603998B RID: 235915 RVA: 0x00E9C734 File Offset: 0x00E9A934
		protected override UniTask OnBeforeStartAsync()
		{
			MingSuNpcMarkItemView.<OnBeforeStartAsync>d__2 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MingSuNpcMarkItemView.<OnBeforeStartAsync>d__2>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603998C RID: 235916 RVA: 0x00E9C777 File Offset: 0x00E9A977
		protected override void OnStart()
		{
			base.OnStart();
			UUIItem iconItem = this.GetIconItem();
			if (iconItem != null)
			{
				iconItem.SetUIActive(false);
			}
			this.NpcIcon.SetUiActive(false);
		}

		// Token: 0x0603998D RID: 235917 RVA: 0x00E9C7A0 File Offset: 0x00E9A9A0
		protected override void OnViewRefresh()
		{
			base.OnViewRefresh();
			MingSuNpcMarkItem mingSuNpcMarkItem = this.Holder as MingSuNpcMarkItem;
			bool isWithSeqNpc = mingSuNpcMarkItem.MarkConfig.Value.RelativeSubType == 12 || mingSuNpcMarkItem.MarkConfig.Value.RelativeSubType == 11;
			if (isWithSeqNpc)
			{
				this.NpcIcon.SetIcon(mingSuNpcMarkItem.IconPath, delegate
				{
					if (this.IsShow)
					{
						this.NpcIcon.SetUiActive(isWithSeqNpc);
						if (isWithSeqNpc)
						{
							this.ProcessSequence();
						}
					}
				});
				this.IsShowIcon = false;
			}
			UUIItem iconItem = this.GetIconItem();
			if (iconItem == null)
			{
				return;
			}
			iconItem.SetUIActive(!isWithSeqNpc);
		}

		// Token: 0x0603998E RID: 235918 RVA: 0x00E9C848 File Offset: 0x00E9AA48
		protected override void OnViewRecycle()
		{
			this.NpcIcon.SetUiActive(false);
		}

		// Token: 0x0603998F RID: 235919 RVA: 0x00E9C858 File Offset: 0x00E9AA58
		private void ProcessSequence()
		{
			if (this.Holder.MarkId == 0 || this.Holder.MapType != EMapType.WorldMap)
			{
				return;
			}
			HashSet<int> hashSet = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.MapNPCMarkShowSeq, null) ?? new HashSet<int>();
			if (!hashSet.Contains(this.Holder.MarkId))
			{
				this.NpcIcon.PlaySequence();
				hashSet.Add(this.Holder.MarkId);
			}
			LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.MapNPCMarkShowSeq, hashSet);
		}

		// Token: 0x06039990 RID: 235920 RVA: 0x00E9C8D2 File Offset: 0x00E9AAD2
		protected override IMarkItemHandle CreateTopRightHandle(IMarkItemComponentContext markComponentContext)
		{
			return new MingSuNpcTopRightIconHandle(markComponentContext);
		}

		// Token: 0x04020AD2 RID: 133842
		private NpcIconPanel NpcIcon = new NpcIconPanel();
	}
}
