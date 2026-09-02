using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A50 RID: 19024
	[NullableContext(1)]
	[Nullable(0)]
	public class UiPopFrameViewInfo
	{
		// Token: 0x06031B63 RID: 203619 RVA: 0x00C63BDF File Offset: 0x00C61DDF
		public UiPopFrameViewInfo(string resourceId, TUiBehaviourPopTypeCtor ctor)
		{
		}

		// Token: 0x0401CEAD RID: 118445
		public string ResourceId = resourceId;

		// Token: 0x0401CEAE RID: 118446
		public TUiBehaviourPopTypeCtor Ctor = ctor;
	}
}
