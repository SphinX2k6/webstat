using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200316B RID: 12651
[NullableContext(2)]
[Nullable(0)]
public class WeaponVisibleTagHelper
{
	// Token: 0x170023A6 RID: 9126
	// (get) Token: 0x0601A391 RID: 107409 RVA: 0x007B482C File Offset: 0x007B2A2C
	// (set) Token: 0x0601A392 RID: 107410 RVA: 0x007B4834 File Offset: 0x007B2A34
	[Nullable(1)]
	public int[] Tags { [NullableContext(1)] get; [NullableContext(1)] private set; } = Array.Empty<int>();

	// Token: 0x170023A7 RID: 9127
	// (get) Token: 0x0601A393 RID: 107411 RVA: 0x007B483D File Offset: 0x007B2A3D
	// (set) Token: 0x0601A394 RID: 107412 RVA: 0x007B4845 File Offset: 0x007B2A45
	public BaseTagComponent TagComp { get; private set; }

	// Token: 0x170023A8 RID: 9128
	// (get) Token: 0x0601A395 RID: 107413 RVA: 0x007B484E File Offset: 0x007B2A4E
	// (set) Token: 0x0601A396 RID: 107414 RVA: 0x007B4856 File Offset: 0x007B2A56
	public CharacterWeapon Owner { get; private set; }

	// Token: 0x0601A397 RID: 107415 RVA: 0x007B485F File Offset: 0x007B2A5F
	public WeaponVisibleTagHelper()
	{
		this.CountCallBack = delegate(int tagId, bool tagExist)
		{
			int tagCount = this.TagCount;
			if (tagExist)
			{
				this.TagCount++;
			}
			else
			{
				this.TagCount--;
			}
			if (tagCount == 0 && this.TagCount > 0)
			{
				this.WeaponCallBack(true, this.Owner);
				return;
			}
			if (tagCount > 0 && this.TagCount == 0)
			{
				this.WeaponCallBack(false, this.Owner);
			}
		};
	}

	// Token: 0x0601A398 RID: 107416 RVA: 0x007B4890 File Offset: 0x007B2A90
	[NullableContext(1)]
	public void Init(CharacterWeapon owner, BaseTagComponent tagComp, [Nullable(new byte[]
	{
		2,
		1
	})] string[] tagNames, Action<bool, CharacterWeapon> callBack)
	{
		if (tagNames == null)
		{
			return;
		}
		this.Clear();
		this.TagCount = 0;
		this.TagComp = tagComp;
		this.WeaponCallBack = callBack;
		this.Owner = owner;
		List<int> list = new List<int>();
		foreach (string text in tagNames)
		{
			if (!string.IsNullOrEmpty(text))
			{
				int tagIdByName = GameplayTagUtils.GetTagIdByName(text);
				list.Add(tagIdByName);
			}
		}
		this.Tags = list.ToArray();
		foreach (int num in this.Tags)
		{
			if (tagComp.HasTag(num))
			{
				this.TagCount++;
			}
			ITagTask tagTask = tagComp.ListenForTagAddOrRemove(new int?(num), this.CountCallBack, null);
			if (tagTask != null)
			{
				this.TagListeners.Add(tagTask);
			}
		}
		if (this.TagCount > 0)
		{
			this.WeaponCallBack(true, this.Owner);
		}
	}

	// Token: 0x0601A399 RID: 107417 RVA: 0x007B497C File Offset: 0x007B2B7C
	public void Clear()
	{
		this.Owner = null;
		this.TagComp = null;
		this.WeaponCallBack = null;
		foreach (ITagTask tagTask in this.TagListeners)
		{
			tagTask.EndTask();
		}
		this.TagListeners.Clear();
		this.Tags = Array.Empty<int>();
	}

	// Token: 0x0400D2F9 RID: 54009
	private int TagCount;

	// Token: 0x0400D2FA RID: 54010
	[Nullable(1)]
	private readonly BaseTagComponent.TTagSwitchedCallback CountCallBack;

	// Token: 0x0400D2FD RID: 54013
	[Nullable(1)]
	private readonly List<ITagTask> TagListeners = new List<ITagTask>();

	// Token: 0x0400D2FE RID: 54014
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<bool, CharacterWeapon> WeaponCallBack;
}
