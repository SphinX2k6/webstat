using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Camera
{
	// Token: 0x0200709A RID: 28826
	public static class CameraNearClipConstructorFactory
	{
		// Token: 0x06045DC3 RID: 286147 RVA: 0x0124B765 File Offset: 0x01249965
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public static ICameraNearClipAction<CameraBaseNearClipConfig> Create(ECameraNearClipType type, int id, CameraBaseNearClipConfig config)
		{
			if (type == ECameraNearClipType.Relative)
			{
				return new CameraRelativeNearClipAction(id, (CameraRelativeNearClipConfig)config);
			}
			if (type == ECameraNearClipType.Absolute)
			{
				return new CameraAbsoluteNearClipAction(id, (CameraAbsoluteNearClipConfig)config);
			}
			return null;
		}
	}
}
