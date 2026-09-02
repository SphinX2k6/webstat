using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Camera
{
	// Token: 0x02007099 RID: 28825
	[NullableContext(1)]
	[Nullable(0)]
	public class CameraAbsoluteNearClipAction : ICameraNearClipAction<CameraAbsoluteNearClipConfig>
	{
		// Token: 0x06045DBC RID: 286140 RVA: 0x0124B47A File Offset: 0x0124967A
		public CameraAbsoluteNearClipAction(int id, CameraAbsoluteNearClipConfig nearClipConfig)
		{
		}

		// Token: 0x1700A5C2 RID: 42434
		// (get) Token: 0x06045DBD RID: 286141 RVA: 0x0124B490 File Offset: 0x01249690
		public CameraAbsoluteNearClipConfig NearClipConfig
		{
			get
			{
				return this.<nearClipConfig>P;
			}
		} = nearClipConfig;

		// Token: 0x06045DBE RID: 286142 RVA: 0x0124B498 File Offset: 0x01249698
		public unsafe void Start()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "[CameraNearClip][CameraAbsoluteNearClipAction]Start";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", this.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Type", this.<nearClipConfig>P.NearClipType);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Distance", this.<nearClipConfig>P.Distance.ToString("F2"));
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			UKuroCameraFunctionLibrary.DelaySetNearClipPlane(this.<nearClipConfig>P.Distance);
		}

		// Token: 0x06045DBF RID: 286143 RVA: 0x0124B54D File Offset: 0x0124974D
		public bool IsPause()
		{
			return this.IsPauseState;
		}

		// Token: 0x06045DC0 RID: 286144 RVA: 0x0124B558 File Offset: 0x01249758
		public unsafe void Pause()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "[CameraNearClip][CameraAbsoluteNearClipAction]Pause";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", this.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Type", this.<nearClipConfig>P.NearClipType);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Distance", this.<nearClipConfig>P.Distance.ToString("F2"));
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			this.IsPauseState = true;
		}

		// Token: 0x06045DC1 RID: 286145 RVA: 0x0124B604 File Offset: 0x01249804
		public unsafe void Resume()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "[CameraNearClip][CameraAbsoluteNearClipAction]Resume";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", this.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Type", this.<nearClipConfig>P.NearClipType);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Distance", this.<nearClipConfig>P.Distance.ToString("F2"));
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			this.IsPauseState = false;
			UKuroCameraFunctionLibrary.DelaySetNearClipPlane(this.<nearClipConfig>P.Distance);
		}

		// Token: 0x06045DC2 RID: 286146 RVA: 0x0124B6C0 File Offset: 0x012498C0
		public unsafe void End()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "[CameraNearClip][CameraAbsoluteNearClipAction]End";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", this.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Type", this.<nearClipConfig>P.NearClipType);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Distance", this.<nearClipConfig>P.Distance.ToString("F2"));
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}

		// Token: 0x040271FB RID: 160251
		[CompilerGenerated]
		private CameraAbsoluteNearClipConfig <nearClipConfig>P;

		// Token: 0x040271FC RID: 160252
		public readonly int Id = id;

		// Token: 0x040271FD RID: 160253
		private bool IsPauseState;
	}
}
