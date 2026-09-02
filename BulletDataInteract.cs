using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;

// Token: 0x02002DA0 RID: 11680
[NullableContext(1)]
[Nullable(0)]
public class BulletDataInteract
{
	// Token: 0x17001F4B RID: 8011
	// (get) Token: 0x0601792E RID: 96558 RVA: 0x0068E915 File Offset: 0x0068CB15
	public FName SceneInteract
	{
		get
		{
			this.InitSceneInteract();
			return this.SceneInteractInternal;
		}
	}

	// Token: 0x17001F4C RID: 8012
	// (get) Token: 0x0601792F RID: 96559 RVA: 0x0068E923 File Offset: 0x0068CB23
	public bool IsSceneInteract
	{
		get
		{
			this.InitSceneInteract();
			return this.IsSceneInteractInternal;
		}
	}

	// Token: 0x06017930 RID: 96560 RVA: 0x0068E931 File Offset: 0x0068CB31
	private void InitSceneInteract()
	{
		if (!this.SceneInteractInit)
		{
			this.SceneInteractInit = true;
			this.SceneInteractInternal = this.Data.场景物件交互.GetAssetPathName();
			this.IsSceneInteractInternal = (this.SceneInteractInternal != FName.NAME_None);
		}
	}

	// Token: 0x06017931 RID: 96561 RVA: 0x0068E96E File Offset: 0x0068CB6E
	public BulletDataInteract(SReBulletDataInteraction data)
	{
		this.Data = data;
	}

	// Token: 0x0400B4FC RID: 46332
	private readonly SReBulletDataInteraction Data;

	// Token: 0x0400B4FD RID: 46333
	private FName SceneInteractInternal = FName.NAME_None;

	// Token: 0x0400B4FE RID: 46334
	private bool IsSceneInteractInternal;

	// Token: 0x0400B4FF RID: 46335
	private bool SceneInteractInit;
}
