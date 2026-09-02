using System;
using System.Runtime.CompilerServices;

// Token: 0x020032B5 RID: 12981
[NullableContext(1)]
[Nullable(0)]
public class FightAssetManager
{
	// Token: 0x0601B35F RID: 111455 RVA: 0x0082D60C File Offset: 0x0082B80C
	public FightAssetManager([Nullable(new byte[]
	{
		0,
		1,
		1
	})] OneOf<EntityAssetElement, PbEntityAssetElement> entityAssetElement)
	{
		this.EntityAssetElement = entityAssetElement;
		this.SkillAssetManager = new SkillAssetManager(this);
		this.BulletAssetManager = new BulletAssetManager(this);
	}

	// Token: 0x0601B360 RID: 111456 RVA: 0x0082D633 File Offset: 0x0082B833
	public void Clear()
	{
		this.SkillAssetManager.Clear();
		this.BulletAssetManager.Clear();
	}

	// Token: 0x0400DDBD RID: 56765
	[Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	public readonly OneOf<EntityAssetElement, PbEntityAssetElement> EntityAssetElement;

	// Token: 0x0400DDBE RID: 56766
	public SkillAssetManager SkillAssetManager;

	// Token: 0x0400DDBF RID: 56767
	public BulletAssetManager BulletAssetManager;
}
