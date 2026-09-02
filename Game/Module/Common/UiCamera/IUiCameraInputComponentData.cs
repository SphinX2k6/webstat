using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.UiRoleCamera.Struct;
using UnrealEngine;

namespace CSharpScript.Game.Module.Common.UiCamera
{
	// Token: 0x02005E49 RID: 24137
	[NullableContext(1)]
	public interface IUiCameraInputComponentData
	{
		// Token: 0x17009938 RID: 39224
		// (get) Token: 0x0603CBB9 RID: 248761
		// (set) Token: 0x0603CBBA RID: 248762
		UUIDraggableComponent DragComponent { get; set; }

		// Token: 0x17009939 RID: 39225
		// (get) Token: 0x0603CBBB RID: 248763
		// (set) Token: 0x0603CBBC RID: 248764
		SUiRoleCameraSetting CameraSettingConfig { get; set; }

		// Token: 0x1700993A RID: 39226
		// (get) Token: 0x0603CBBD RID: 248765
		// (set) Token: 0x0603CBBE RID: 248766
		SUiRoleCameraOffsetSetting? CameraOffsetConfig { get; set; }

		// Token: 0x1700993B RID: 39227
		// (get) Token: 0x0603CBBF RID: 248767
		// (set) Token: 0x0603CBC0 RID: 248768
		FVector SourceLocation { get; set; }
	}
}
