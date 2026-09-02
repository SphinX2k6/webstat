using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Map.MapDefine;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView.Components
{
	// Token: 0x020058AC RID: 22700
	public class MarkTrackComponent : MarkPanelBase
	{
		// Token: 0x06039AC6 RID: 236230 RVA: 0x00E9F9B4 File Offset: 0x00E9DBB4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUINiagara));
			this.ComponentRegisterInfos = list;
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
		}

		// Token: 0x06039AC7 RID: 236231 RVA: 0x00E9FA08 File Offset: 0x00E9DC08
		protected override void OnStart()
		{
			UUINiagara uiNiagara = base.GetUiNiagara(0);
			if (uiNiagara != null)
			{
				if (this.MapType == EMapType.WorldMap)
				{
					uiNiagara.bAdaptPosAndSizeChanged = true;
				}
				else
				{
					uiNiagara.bAdaptPosAndSizeChanged = false;
				}
			}
			Vector vector = new Vector((double)this.TrackFxScale, (double)this.TrackFxScale, 1.0);
			UUIItem rootItem = this.RootItem;
			FVectorDouble fvectorDouble = vector.ToUeVector(false);
			FVector fvector = fvectorDouble;
			rootItem.SetUIRelativeScale3D(fvector);
		}

		// Token: 0x04020AFC RID: 133884
		public EMapType MapType = EMapType.WorldMap;

		// Token: 0x04020AFD RID: 133885
		public float TrackFxScale = 1f;

		// Token: 0x0200B8DE RID: 47326
		public static class EMarkTrackNiaComponents
		{
			// Token: 0x04039240 RID: 234048
			public const int NiaTrace = 0;
		}
	}
}
