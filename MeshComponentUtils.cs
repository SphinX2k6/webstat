using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020030BD RID: 12477
[NullableContext(1)]
[Nullable(0)]
public class MeshComponentUtils
{
	// Token: 0x06019B6F RID: 105327 RVA: 0x0077BB6C File Offset: 0x00779D6C
	public static void RelativeAttachComponent(USceneComponent child, USceneComponent parent, string socketName = "")
	{
		child.K2_AttachToComponent(parent, new FName(socketName), EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, true, true);
	}

	// Token: 0x06019B70 RID: 105328 RVA: 0x0077BB81 File Offset: 0x00779D81
	public static bool RelativeAttachComponentOnSafe(USceneComponent child, USceneComponent parent, string socketName = "")
	{
		if (parent == child.GetAttachParent())
		{
			return false;
		}
		MeshComponentUtils.RelativeAttachComponent(child, parent, socketName);
		return true;
	}

	// Token: 0x06019B71 RID: 105329 RVA: 0x0077BB98 File Offset: 0x00779D98
	public static void HideBone(USkeletalMeshComponent meshComp, string boneName, bool hide)
	{
		FName? dynamicFName = FNameUtil.GetDynamicFName(boneName);
		if (FNameUtil.IsEmpty(new FName?(meshComp.GetParentBone(dynamicFName ?? FName.NAME_None))))
		{
			meshComp.SetHiddenInGame(hide, false);
			return;
		}
		if (meshComp.IsBoneHiddenByName(dynamicFName ?? FName.NAME_None) == hide)
		{
			return;
		}
		if (hide)
		{
			meshComp.HideBoneByName(dynamicFName ?? FName.NAME_None, EPhysBodyOp.PBO_None);
			return;
		}
		meshComp.UnHideBoneByName(dynamicFName ?? FName.NAME_None);
	}
}
