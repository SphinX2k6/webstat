using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Utils
{
	// Token: 0x020046FD RID: 18173
	[NullableContext(1)]
	[Nullable(0)]
	public class TraceUtils
	{
		// Token: 0x0602F412 RID: 193554 RVA: 0x00B34D00 File Offset: 0x00B32F00
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public static ValueTuple<bool, UKuroHitResult> LineTraceWithLocation(Vector location, float startOffset, float endOffset)
		{
			Vector commonStartLocation = ModelBase<TraceElementModel>.Instance.CommonStartLocation;
			commonStartLocation.Set(location.X, location.Y, location.Z + (double)startOffset);
			Vector commonEndLocation = ModelBase<TraceElementModel>.Instance.CommonEndLocation;
			commonEndLocation.Set(location.X, location.Y, location.Z + (double)endOffset);
			UTraceLineElement lineTrace = ModelBase<TraceElementModel>.Instance.GetLineTrace();
			lineTrace.WorldContextObject = GlobalData.World;
			lineTrace.ActorsToIgnore.Empty(true);
			Singleton<TraceElementCommon>.Instance.SetStartLocation(lineTrace, commonStartLocation);
			Singleton<TraceElementCommon>.Instance.SetEndLocation(lineTrace, commonEndLocation);
			bool item = Singleton<TraceElementCommon>.Instance.LineTrace(lineTrace, "TraceUtil");
			UKuroHitResult hitResult = lineTrace.HitResult;
			lineTrace.ClearCacheData(false);
			return new ValueTuple<bool, UKuroHitResult>(item, hitResult);
		}

		// Token: 0x0401AEC1 RID: 110273
		private const string PROFILE_KEY = "TraceUtil";
	}
}
