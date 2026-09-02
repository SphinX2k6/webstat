using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067AB RID: 26539
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DockyardInteractGrid : GridProxyAbstract<IPanelPos>
	{
		// Token: 0x1700A0FC RID: 41212
		// (get) Token: 0x060422E0 RID: 271072 RVA: 0x010F9D1E File Offset: 0x010F7F1E
		// (set) Token: 0x060422DF RID: 271071 RVA: 0x010F9CFA File Offset: 0x010F7EFA
		public EDockyardInteractGridShowType ShowType
		{
			get
			{
				return this.ShowTypeInternal;
			}
			set
			{
				if (this.ShowTypeInternal == value)
				{
					return;
				}
				this.ShowTypeInternal = value;
				this.StateFunc[value]();
			}
		}

		// Token: 0x060422E1 RID: 271073 RVA: 0x010F9D28 File Offset: 0x010F7F28
		private void SetEmptyState()
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_GridEmpty");
			this.SetSpriteByPath(resourcePath, this.BgSprite, false, null, null);
			this.BgSprite.SetUIActive(true);
		}

		// Token: 0x060422E2 RID: 271074 RVA: 0x010F9D6C File Offset: 0x010F7F6C
		private void SetOutlineState()
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_GridFinsh");
			this.SetSpriteByPath(resourcePath, this.BgSprite, false, null, null);
			this.BgSprite.SetUIActive(true);
		}

		// Token: 0x060422E3 RID: 271075 RVA: 0x010F9DB0 File Offset: 0x010F7FB0
		private void SetPreviewErrorState()
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_GridError");
			this.SetSpriteByPath(resourcePath, this.BgSprite, false, null, null);
			this.BgSprite.SetUIActive(true);
		}

		// Token: 0x060422E4 RID: 271076 RVA: 0x010F9DF4 File Offset: 0x010F7FF4
		private void SetPreviewOccupancyState()
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_GridReplace");
			this.SetSpriteByPath(resourcePath, this.BgSprite, false, null, null);
			this.BgSprite.SetUIActive(true);
		}

		// Token: 0x060422E5 RID: 271077 RVA: 0x010F9E38 File Offset: 0x010F8038
		private void SetPreviewMatchState()
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_GridFinsh");
			this.SetSpriteByPath(resourcePath, this.BgSprite, false, null, null);
			this.BgSprite.SetUIActive(true);
		}

		// Token: 0x060422E6 RID: 271078 RVA: 0x010F9E7C File Offset: 0x010F807C
		private void SetMatchState()
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_GridFinsh");
			this.SetSpriteByPath(resourcePath, this.BgSprite, false, null, null);
			this.BgSprite.SetUIActive(true);
		}

		// Token: 0x060422E7 RID: 271079 RVA: 0x010F9EC0 File Offset: 0x010F80C0
		public DockyardInteractGrid(DockyardInteractPanelModel parentModel)
		{
			this.ParentModel = parentModel;
			this.StateFunc = new Dictionary<EDockyardInteractGridShowType, Action>
			{
				{
					EDockyardInteractGridShowType.None,
					null
				},
				{
					EDockyardInteractGridShowType.Empty,
					new Action(this.SetEmptyState)
				},
				{
					EDockyardInteractGridShowType.Outline,
					new Action(this.SetOutlineState)
				},
				{
					EDockyardInteractGridShowType.PreviewError,
					new Action(this.SetPreviewErrorState)
				},
				{
					EDockyardInteractGridShowType.PreviewOccupancy,
					new Action(this.SetPreviewOccupancyState)
				},
				{
					EDockyardInteractGridShowType.PreviewMatch,
					new Action(this.SetPreviewMatchState)
				},
				{
					EDockyardInteractGridShowType.Match,
					new Action(this.SetMatchState)
				}
			};
		}

		// Token: 0x060422E8 RID: 271080 RVA: 0x010F9F60 File Offset: 0x010F8160
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060422E9 RID: 271081 RVA: 0x010F9FC9 File Offset: 0x010F81C9
		protected override void OnStart()
		{
			this.BgSprite = base.GetSprite(0);
			UUIItem item = base.GetItem(1);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x060422EA RID: 271082 RVA: 0x010F9FEA File Offset: 0x010F81EA
		public override void Refresh(IPanelPos pos, bool isSelected, int gridIndex)
		{
			this.InteractGridData = this.ParentModel.GetInteractGridData(pos);
			this.ShowType = (this.InteractGridData.IsFinish ? EDockyardInteractGridShowType.Match : EDockyardInteractGridShowType.Empty);
		}

		// Token: 0x060422EB RID: 271083 RVA: 0x010FA015 File Offset: 0x010F8215
		public void RefreshBgSprite(bool isAllMatch)
		{
			if (!isAllMatch)
			{
				this.ShowType = EDockyardInteractGridShowType.PreviewError;
				return;
			}
			if (this.InteractGridData.IsFinish)
			{
				this.ShowType = EDockyardInteractGridShowType.PreviewOccupancy;
				return;
			}
			this.ShowType = EDockyardInteractGridShowType.PreviewMatch;
		}

		// Token: 0x060422EC RID: 271084 RVA: 0x010FA03E File Offset: 0x010F823E
		public void ResetPreviewBg()
		{
			if (this.InteractGridData.IsFinish)
			{
				this.ShowType = EDockyardInteractGridShowType.Match;
				return;
			}
			this.ShowType = EDockyardInteractGridShowType.Empty;
		}

		// Token: 0x060422ED RID: 271085 RVA: 0x010FA05C File Offset: 0x010F825C
		public int GetTargetItemId()
		{
			return this.InteractGridData.TargetId;
		}

		// Token: 0x1700A0FD RID: 41213
		// (get) Token: 0x060422EE RID: 271086 RVA: 0x010FA069 File Offset: 0x010F8269
		public bool IsFinishInteract
		{
			get
			{
				return this.InteractGridData.IsFinish;
			}
		}

		// Token: 0x060422EF RID: 271087 RVA: 0x010FA076 File Offset: 0x010F8276
		public override object GetKey(IPanelPos data, int displayIndex)
		{
			return data;
		}

		// Token: 0x04024DDE RID: 151006
		private DockyardInteractGridData InteractGridData;

		// Token: 0x04024DDF RID: 151007
		private UUISprite BgSprite;

		// Token: 0x04024DE0 RID: 151008
		private readonly DockyardInteractPanelModel ParentModel;

		// Token: 0x04024DE1 RID: 151009
		private EDockyardInteractGridShowType ShowTypeInternal;

		// Token: 0x04024DE2 RID: 151010
		private Dictionary<EDockyardInteractGridShowType, Action> StateFunc;

		// Token: 0x0200C7CD RID: 51149
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403D813 RID: 251923
			public const int BgSprite = 0;

			// Token: 0x0403D814 RID: 251924
			public const int QuicklySellItem = 1;
		}
	}
}
