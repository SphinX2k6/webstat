using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.WorldMap.ViewComponent;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews
{
	// Token: 0x02004B5E RID: 19294
	[NullableContext(1)]
	[Nullable(0)]
	public class WorldMapExtraUiPanel : UiPanelBase
	{
		// Token: 0x06032652 RID: 206418 RVA: 0x00C9C628 File Offset: 0x00C9A828
		public WorldMapExtraUiPanel(EWorldMapExtraUiPanelName panelName, WorldMapExtraUiPanelComponent extraUiPanelComponent)
		{
			this.PanelName = panelName;
			this.ExtraUiPanelComponent = extraUiPanelComponent;
		}

		// Token: 0x06032653 RID: 206419 RVA: 0x00C9C657 File Offset: 0x00C9A857
		[NullableContext(2)]
		public virtual UUISliderComponent GetScaleSlider()
		{
			return null;
		}

		// Token: 0x06032654 RID: 206420 RVA: 0x00C9C65A File Offset: 0x00C9A85A
		[NullableContext(2)]
		public virtual void OnHandleShowParam(object param = null)
		{
		}

		// Token: 0x06032655 RID: 206421 RVA: 0x00C9C65C File Offset: 0x00C9A85C
		public virtual bool OnClickEmpty(Vector2D clickedPosition)
		{
			return false;
		}

		// Token: 0x06032656 RID: 206422 RVA: 0x00C9C65F File Offset: 0x00C9A85F
		public virtual ClickMarkItemRet OnClickMarkItem(MarkItem clickedItem)
		{
			return this.ClickMarkItemRetData;
		}

		// Token: 0x06032657 RID: 206423 RVA: 0x00C9C667 File Offset: 0x00C9A867
		public virtual bool OnClickMarks(List<MarkItem> clickedItems, Vector2D clickedPosition)
		{
			return false;
		}

		// Token: 0x06032658 RID: 206424 RVA: 0x00C9C66C File Offset: 0x00C9A86C
		public virtual int? GetCustomClickRange()
		{
			return null;
		}

		// Token: 0x06032659 RID: 206425 RVA: 0x00C9C682 File Offset: 0x00C9A882
		public virtual bool GetIsEnableMapScale()
		{
			return true;
		}

		// Token: 0x0603265A RID: 206426 RVA: 0x00C9C685 File Offset: 0x00C9A885
		public virtual bool GetIsEnableMapCursorButton()
		{
			return true;
		}

		// Token: 0x0603265B RID: 206427 RVA: 0x00C9C688 File Offset: 0x00C9A888
		public virtual bool OnPointerDrag(Vector2D delta)
		{
			return false;
		}

		// Token: 0x0603265C RID: 206428 RVA: 0x00C9C68B File Offset: 0x00C9A88B
		protected void CloseMe()
		{
			this.ExtraUiPanelComponent.CloseUi(this);
		}

		// Token: 0x0603265D RID: 206429 RVA: 0x00C9C699 File Offset: 0x00C9A899
		public virtual float GetDefaultMapScale()
		{
			return 0f;
		}

		// Token: 0x0603265E RID: 206430 RVA: 0x00C9C6A0 File Offset: 0x00C9A8A0
		public virtual float GetMaxMapScale()
		{
			return 0f;
		}

		// Token: 0x0603265F RID: 206431 RVA: 0x00C9C6A7 File Offset: 0x00C9A8A7
		public virtual float GetMinMapScale()
		{
			return 0f;
		}

		// Token: 0x06032660 RID: 206432 RVA: 0x00C9C6AE File Offset: 0x00C9A8AE
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public virtual IEnumerable<string> GetTileRange()
		{
			return null;
		}

		// Token: 0x06032661 RID: 206433 RVA: 0x00C9C6B1 File Offset: 0x00C9A8B1
		public virtual bool GetIsShowPlayerMark()
		{
			return false;
		}

		// Token: 0x06032662 RID: 206434 RVA: 0x00C9C6B4 File Offset: 0x00C9A8B4
		public virtual EMarkType[] GetExtraMarkTypes()
		{
			return Array.Empty<EMarkType>();
		}

		// Token: 0x06032663 RID: 206435 RVA: 0x00C9C6BB File Offset: 0x00C9A8BB
		[NullableContext(2)]
		public virtual int[] GetExtraMarkIds()
		{
			return null;
		}

		// Token: 0x06032664 RID: 206436 RVA: 0x00C9C6BE File Offset: 0x00C9A8BE
		[NullableContext(2)]
		public virtual int[] GetUnlockFogs()
		{
			return null;
		}

		// Token: 0x06032665 RID: 206437 RVA: 0x00C9C6C1 File Offset: 0x00C9A8C1
		public virtual bool GetIsShowAreaMarkProgress()
		{
			return false;
		}

		// Token: 0x06032666 RID: 206438 RVA: 0x00C9C6C4 File Offset: 0x00C9A8C4
		public virtual bool GetIsCanAutoPilotTrack()
		{
			return false;
		}

		// Token: 0x06032667 RID: 206439 RVA: 0x00C9C6C7 File Offset: 0x00C9A8C7
		public virtual bool GetIsMapRangeVisible()
		{
			return false;
		}

		// Token: 0x06032668 RID: 206440 RVA: 0x00C9C6CA File Offset: 0x00C9A8CA
		public virtual bool GetIsMultiMapVisible()
		{
			return false;
		}

		// Token: 0x06032669 RID: 206441 RVA: 0x00C9C6D0 File Offset: 0x00C9A8D0
		[return: TupleElementNames(new string[]
		{
			"ResourceId",
			"SequenceType"
		})]
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public virtual ValueTuple<string, string>? GetStartSequenceInfo()
		{
			return null;
		}

		// Token: 0x0603266A RID: 206442 RVA: 0x00C9C6E6 File Offset: 0x00C9A8E6
		[NullableContext(2)]
		public virtual string GetBackgroundMusicAudioEvent()
		{
			return null;
		}

		// Token: 0x0603266B RID: 206443 RVA: 0x00C9C6E9 File Offset: 0x00C9A8E9
		[NullableContext(2)]
		public virtual void SetOpenParam(object openParam)
		{
			this.OpenParam = openParam;
		}

		// Token: 0x0401D6B0 RID: 120496
		public readonly EWorldMapExtraUiPanelName PanelName;

		// Token: 0x0401D6B1 RID: 120497
		public readonly WorldMapExtraUiPanelComponent ExtraUiPanelComponent;

		// Token: 0x0401D6B2 RID: 120498
		protected readonly ClickMarkItemRet ClickMarkItemRetData = new ClickMarkItemRet
		{
			IsExtraUiLogic = false,
			IsNeedSelected = true
		};
	}
}
