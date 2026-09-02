using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Mark.Component;
using CSharpScript.Game.Module.Map.Marks;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.MarkMenu
{
	// Token: 0x02004B9A RID: 19354
	[NullableContext(2)]
	[Nullable(0)]
	public class MarkMenuItem : UiPanelBase
	{
		// Token: 0x0603289A RID: 207002 RVA: 0x00CA6D34 File Offset: 0x00CA4F34
		[NullableContext(1)]
		public UniTask Init(UUIItem uiItem, MarkItem markItem)
		{
			MarkMenuItem.<Init>d__3 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.uiItem = uiItem;
			<Init>d__.markItem = markItem;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<MarkMenuItem.<Init>d__3>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x0603289B RID: 207003 RVA: 0x00CA6D88 File Offset: 0x00CA4F88
		protected override void OnStart()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			AUIBaseActor auibaseActor = ((extendToggle != null) ? extendToggle.GetOwner() : null) as AUIBaseActor;
			UUIItem uuiitem = (auibaseActor != null) ? auibaseActor.GetUIItem() : null;
			this.MarkInfoTextSizeAdapterProxy = new UiTextAdapterProxy(base.GetText(2));
			UiTextAdapterProxy markInfoTextSizeAdapterProxy = this.MarkInfoTextSizeAdapterProxy;
			if (markInfoTextSizeAdapterProxy != null)
			{
				markInfoTextSizeAdapterProxy.Init();
			}
			if (uuiitem != null)
			{
				this.LevelSequencePlayer = new LevelSequencePlayer(uuiitem);
			}
		}

		// Token: 0x0603289C RID: 207004 RVA: 0x00CA6DEC File Offset: 0x00CA4FEC
		protected override void OnBeforeShow()
		{
			this.PlayAppearSequence();
		}

		// Token: 0x0603289D RID: 207005 RVA: 0x00CA6DF4 File Offset: 0x00CA4FF4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603289E RID: 207006 RVA: 0x00CA6EC0 File Offset: 0x00CA50C0
		[NullableContext(1)]
		public void SetOnClick(Action<EToggleState> onClick)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			FOnToggleStateChange onStateChange = extendToggle.OnStateChange;
			if (onStateChange == null)
			{
				return;
			}
			onStateChange.Add(onClick);
		}

		// Token: 0x0603289F RID: 207007 RVA: 0x00CA6EE0 File Offset: 0x00CA50E0
		private void SetUp()
		{
			if (this.MarkItem == null)
			{
				return;
			}
			this.SetSpriteByPath(this.MarkItem.IconPath, base.GetSprite(1), false, null, null);
			EnrichmentAreaItem enrichmentAreaItem = this.MarkItem as EnrichmentAreaItem;
			if (enrichmentAreaItem != null)
			{
				string markTitle = enrichmentAreaItem.MarkConfig.MarkTitle;
				MapConfig instance = ConfigBase<MapConfig>.Instance;
				string text = (instance != null) ? instance.GetLocalText(enrichmentAreaItem.GetEnrichmentItemNameId()) : null;
				UiTextAdapterProxy markInfoTextSizeAdapterProxy = this.MarkInfoTextSizeAdapterProxy;
				if (markInfoTextSizeAdapterProxy != null)
				{
					markInfoTextSizeAdapterProxy.SetLocalText(markTitle, new object[]
					{
						text
					});
				}
			}
			else
			{
				UiTextAdapterProxy markInfoTextSizeAdapterProxy2 = this.MarkInfoTextSizeAdapterProxy;
				if (markInfoTextSizeAdapterProxy2 != null)
				{
					markInfoTextSizeAdapterProxy2.SetText(this.MarkItem.GetTitleText());
				}
			}
			MarkItemEntity markItemEntity = this.MarkItem.MarkItemEntity;
			MarkViewLifeCircleComponent markViewLifeCircleComponent = (markItemEntity != null) ? markItemEntity.ViewLifeCircle : null;
			if (markViewLifeCircleComponent != null)
			{
				bool flag = markViewLifeCircleComponent.IsChildViewVisible(EMarkViewComponentType.ChildIcon, false);
				UUISprite sprite = base.GetSprite(3);
				if (sprite != null)
				{
					sprite.SetUIActive(flag);
				}
				if (flag)
				{
					string childIconPath = this.MarkItem.MarkItemEntity.Resource.ChildIconPath;
					this.SetSpriteByPath(childIconPath, base.GetSprite(3), false, null, null);
				}
				bool flag2 = markViewLifeCircleComponent.IsChildViewVisible(EMarkViewComponentType.TopRightIcon, false);
				UUISprite sprite2 = base.GetSprite(4);
				if (sprite2 != null)
				{
					sprite2.SetUIActive(flag2);
				}
				if (flag2)
				{
					string topRightIconPath = this.MarkItem.MarkItemEntity.Resource.TopRightIconPath;
					this.SetSpriteByPath(topRightIconPath, base.GetSprite(4), false, null, null);
				}
			}
		}

		// Token: 0x060328A0 RID: 207008 RVA: 0x00CA7050 File Offset: 0x00CA5250
		protected override UniTask OnBeforeHideAsync()
		{
			MarkMenuItem.<OnBeforeHideAsync>d__9 <OnBeforeHideAsync>d__;
			<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeHideAsync>d__.<>4__this = this;
			<OnBeforeHideAsync>d__.<>1__state = -1;
			<OnBeforeHideAsync>d__.<>t__builder.Start<MarkMenuItem.<OnBeforeHideAsync>d__9>(ref <OnBeforeHideAsync>d__);
			return <OnBeforeHideAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060328A1 RID: 207009 RVA: 0x00CA7094 File Offset: 0x00CA5294
		protected override void OnBeforeDestroy()
		{
			UiTextAdapterProxy markInfoTextSizeAdapterProxy = this.MarkInfoTextSizeAdapterProxy;
			if (markInfoTextSizeAdapterProxy != null)
			{
				markInfoTextSizeAdapterProxy.Clear();
			}
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				FOnToggleStateChange onStateChange = extendToggle.OnStateChange;
				if (onStateChange != null)
				{
					onStateChange.Clear();
				}
			}
			if (this.LevelSequencePlayer != null)
			{
				this.LevelSequencePlayer.Clear();
			}
			this.LevelSequencePlayer = null;
		}

		// Token: 0x060328A2 RID: 207010 RVA: 0x00CA70EC File Offset: 0x00CA52EC
		public UniTask PlayReleaseSequence()
		{
			MarkMenuItem.<PlayReleaseSequence>d__11 <PlayReleaseSequence>d__;
			<PlayReleaseSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayReleaseSequence>d__.<>4__this = this;
			<PlayReleaseSequence>d__.<>1__state = -1;
			<PlayReleaseSequence>d__.<>t__builder.Start<MarkMenuItem.<PlayReleaseSequence>d__11>(ref <PlayReleaseSequence>d__);
			return <PlayReleaseSequence>d__.<>t__builder.Task;
		}

		// Token: 0x060328A3 RID: 207011 RVA: 0x00CA7130 File Offset: 0x00CA5330
		public void PlayAppearSequence()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		}

		// Token: 0x060328A4 RID: 207012 RVA: 0x00CA7160 File Offset: 0x00CA5360
		public UniTask PlayDisappearSequence()
		{
			MarkMenuItem.<PlayDisappearSequence>d__13 <PlayDisappearSequence>d__;
			<PlayDisappearSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayDisappearSequence>d__.<>4__this = this;
			<PlayDisappearSequence>d__.<>1__state = -1;
			<PlayDisappearSequence>d__.<>t__builder.Start<MarkMenuItem.<PlayDisappearSequence>d__13>(ref <PlayDisappearSequence>d__);
			return <PlayDisappearSequence>d__.<>t__builder.Task;
		}

		// Token: 0x0401D77F RID: 120703
		private MarkItem MarkItem;

		// Token: 0x0401D780 RID: 120704
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0401D781 RID: 120705
		private UiTextAdapterProxy MarkInfoTextSizeAdapterProxy;

		// Token: 0x0200AC73 RID: 44147
		[NullableContext(0)]
		private enum EComponents
		{
			// Token: 0x040359BD RID: 219581
			Toggle,
			// Token: 0x040359BE RID: 219582
			Icon,
			// Token: 0x040359BF RID: 219583
			Info,
			// Token: 0x040359C0 RID: 219584
			SprState,
			// Token: 0x040359C1 RID: 219585
			TopRightIcon
		}
	}
}
