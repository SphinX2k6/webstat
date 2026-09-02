using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.UiRoleCamera.Struct;
using UnrealEngine;

namespace CSharpScript.Game.Module.Common.UiCamera
{
	// Token: 0x02005E4A RID: 24138
	[NullableContext(1)]
	[Nullable(0)]
	public class UiCameraInputComponentData : IUiCameraInputComponentData
	{
		// Token: 0x1700993C RID: 39228
		// (get) Token: 0x0603CBC1 RID: 248769 RVA: 0x00F6C594 File Offset: 0x00F6A794
		// (set) Token: 0x0603CBC2 RID: 248770 RVA: 0x00F6C59C File Offset: 0x00F6A79C
		public UUIDraggableComponent DragComponent { get; set; }

		// Token: 0x1700993D RID: 39229
		// (get) Token: 0x0603CBC3 RID: 248771 RVA: 0x00F6C5A5 File Offset: 0x00F6A7A5
		// (set) Token: 0x0603CBC4 RID: 248772 RVA: 0x00F6C5AD File Offset: 0x00F6A7AD
		public SUiRoleCameraSetting CameraSettingConfig { get; set; }

		// Token: 0x1700993E RID: 39230
		// (get) Token: 0x0603CBC5 RID: 248773 RVA: 0x00F6C5B6 File Offset: 0x00F6A7B6
		// (set) Token: 0x0603CBC6 RID: 248774 RVA: 0x00F6C5BE File Offset: 0x00F6A7BE
		public SUiRoleCameraOffsetSetting? CameraOffsetConfig { get; set; }

		// Token: 0x1700993F RID: 39231
		// (get) Token: 0x0603CBC7 RID: 248775 RVA: 0x00F6C5C7 File Offset: 0x00F6A7C7
		// (set) Token: 0x0603CBC8 RID: 248776 RVA: 0x00F6C5CF File Offset: 0x00F6A7CF
		public FVector SourceLocation { get; set; }
	}
}
