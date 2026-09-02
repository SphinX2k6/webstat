using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.SeekTrace.View
{
	// Token: 0x02006B12 RID: 27410
	public class SeekTraceStartView : UiViewBase
	{
		// Token: 0x06043BBA RID: 277434 RVA: 0x0117A3E6 File Offset: 0x011785E6
		[NullableContext(1)]
		public SeekTraceStartView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06043BBB RID: 277435 RVA: 0x0117A3EF File Offset: 0x011785EF
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem))
			};
		}

		// Token: 0x06043BBC RID: 277436 RVA: 0x0117A414 File Offset: 0x01178614
		protected override UniTask OnBeforeStartAsync()
		{
			SeekTraceStartView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SeekTraceStartView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06043BBD RID: 277437 RVA: 0x0117A457 File Offset: 0x01178657
		protected override void OnStart()
		{
			TimerSystem.Instance.Delay(delegate(float _)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.SeekTraceView, null, null);
				base.CloseMe(null);
			}, 2000f, null, null, true, 1f);
		}

		// Token: 0x04025DE3 RID: 155107
		public const int DELAY_TIME = 2000;

		// Token: 0x04025DE4 RID: 155108
		[Nullable(2)]
		private SeekTraceClawItem ClawItem;

		// Token: 0x0200CA0C RID: 51724
		public enum EComponentType
		{
			// Token: 0x0403E148 RID: 254280
			ClawItem
		}
	}
}
