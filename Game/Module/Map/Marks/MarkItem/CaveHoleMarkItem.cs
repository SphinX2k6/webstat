using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;
using CSharpScript.Game.Module.WorldMap;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItem
{
	// Token: 0x02005838 RID: 22584
	[NullableContext(1)]
	[Nullable(0)]
	public class CaveHoleMarkItem : ConfigMarkItem
	{
		// Token: 0x0603968A RID: 235146 RVA: 0x00E93648 File Offset: 0x00E91848
		public CaveHoleMarkItem(int markId, MapMark config, UUIItem parent, EMapType mapType, float markScale, ETrackSource trackSource = ETrackSource.MapMark) : base(markId, config, parent, mapType, markScale, new ETrackSource?((config.InstanceDungeonId != 0) ? ETrackSource.Instance : trackSource))
		{
		}

		// Token: 0x0603968B RID: 235147 RVA: 0x00E9366A File Offset: 0x00E9186A
		protected override void OnInitialize()
		{
			this.UpdateMultiMapFloorSelectedState();
			base.OnInitialize();
		}

		// Token: 0x0603968C RID: 235148 RVA: 0x00E93678 File Offset: 0x00E91878
		protected override EMarkItemViewType GetMarkItemViewType()
		{
			return EMarkItemViewType.CaveHoleMarkItemView;
		}

		// Token: 0x0603968D RID: 235149 RVA: 0x00E9367B File Offset: 0x00E9187B
		protected override MarkItemView CreateView()
		{
			return new CaveHoleMarkItemView(this);
		}

		// Token: 0x0603968E RID: 235150 RVA: 0x00E93684 File Offset: 0x00E91884
		public override bool CheckCanShowView()
		{
			bool flag = base.CheckCanShowView();
			if (this.IsMultiMap())
			{
				int multiMapId = this.GetMultiMapId();
				Span<int> connectMultiMapIds = base.GetConnectMultiMapIds();
				bool flag2 = this.ConnectGround();
				int? worldMapCurrentMultiMapId = ModelBase<WorldMapModel>.Instance.WorldMapCurrentMultiMapId;
				bool flag3;
				if (!flag2)
				{
					int num = multiMapId;
					int? num2 = worldMapCurrentMultiMapId;
					if (!(num == num2.GetValueOrDefault() & num2 != null))
					{
						flag3 = connectMultiMapIds.Contains(worldMapCurrentMultiMapId.GetValueOrDefault());
						goto IL_57;
					}
				}
				flag3 = true;
				IL_57:
				bool flag4 = flag3;
				return flag && flag4;
			}
			return flag;
		}

		// Token: 0x0603968F RID: 235151 RVA: 0x00E936F0 File Offset: 0x00E918F0
		protected override void OnUpdate(global::Vector playerLocation)
		{
			base.OnUpdate(playerLocation);
			if (base.MapType == EMapType.MiniMap)
			{
				this.UpdateMultiMapFloorSelectedState();
			}
		}

		// Token: 0x06039690 RID: 235152 RVA: 0x00E93708 File Offset: 0x00E91908
		public override bool GetIsSelectThisFloor()
		{
			if (!this.IsMultiMap())
			{
				return this.LocateInGround();
			}
			int multiMapId = this.GetMultiMapId();
			int multiMapFloorId = this.MarkConfig.Value.MultiMapFloorId;
			if (base.MapType == EMapType.MiniMap)
			{
				return base.InMultiMapArea(multiMapId) || base.InMultiMapArea(multiMapFloorId);
			}
			int? worldMapCurrentMultiMapId = ModelBase<WorldMapModel>.Instance.WorldMapCurrentMultiMapId;
			int? num = worldMapCurrentMultiMapId;
			int num2 = multiMapId;
			if (!(num.GetValueOrDefault() == num2 & num != null))
			{
				num = worldMapCurrentMultiMapId;
				num2 = multiMapFloorId;
				return num.GetValueOrDefault() == num2 & num != null;
			}
			return true;
		}

		// Token: 0x06039691 RID: 235153 RVA: 0x00E9379C File Offset: 0x00E9199C
		private void UpdateMultiMapFloorSelectedState()
		{
			bool isSelectThisFloor = base.IsSelectThisFloor;
			base.IsSelectThisFloor = this.GetIsSelectThisFloor();
			if (isSelectThisFloor != base.IsSelectThisFloor)
			{
				base.UpdateViewIcon();
			}
		}
	}
}
