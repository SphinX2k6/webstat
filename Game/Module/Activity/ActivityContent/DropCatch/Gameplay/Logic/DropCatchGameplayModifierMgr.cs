using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic
{
	// Token: 0x0200693D RID: 26941
	[NullableContext(1)]
	[Nullable(0)]
	public class DropCatchGameplayModifierMgr : DropCatchGameplayBaseMgr
	{
		// Token: 0x06042DC8 RID: 273864 RVA: 0x01129807 File Offset: 0x01127A07
		public DropCatchGameplayModifierMgr(IGameplayLogicContext context) : base(context)
		{
		}

		// Token: 0x06042DC9 RID: 273865 RVA: 0x0112983C File Offset: 0x01127A3C
		public override void Init()
		{
			this.Modifiers.Clear();
			this.ModifierIdCounter = 0;
			this.AttrToRefresh.Clear();
			this.ModifiersToDelete.Clear();
		}

		// Token: 0x06042DCA RID: 273866 RVA: 0x01129868 File Offset: 0x01127A68
		public override void OnTick(float deltaTime)
		{
			this.AttrToRefresh.Clear();
			foreach (KeyValuePair<IDropCatchGameplayAttribute, Dictionary<int, IDropCatchGameplayModifier>> keyValuePair in this.Modifiers)
			{
				IDropCatchGameplayAttribute key = keyValuePair.Key;
				Dictionary<int, IDropCatchGameplayModifier> value = keyValuePair.Value;
				this.ModifiersToDelete.Clear();
				bool flag = false;
				foreach (KeyValuePair<int, IDropCatchGameplayModifier> keyValuePair2 in value)
				{
					int key2 = keyValuePair2.Key;
					IDropCatchGameplayModifier value2 = keyValuePair2.Value;
					if (value2.Duration != null)
					{
						float? duration = value2.Duration;
						float num = 0f;
						if (!(duration.GetValueOrDefault() <= num & duration != null))
						{
							value2.Duration -= deltaTime;
							duration = value2.Duration;
							num = 0f;
							if (duration.GetValueOrDefault() <= num & duration != null)
							{
								this.ModifiersToDelete.Add(key2);
								flag = true;
							}
						}
					}
				}
				foreach (int key3 in this.ModifiersToDelete)
				{
					value.Remove(key3);
				}
				if (flag)
				{
					this.AttrToRefresh.Add(key);
				}
			}
			foreach (IDropCatchGameplayAttribute attr in this.AttrToRefresh)
			{
				this.RefreshValueByAttr(attr);
			}
		}

		// Token: 0x06042DCB RID: 273867 RVA: 0x01129AA8 File Offset: 0x01127CA8
		public int AddModifierToAttr(IDropCatchGameplayAttribute attr, EDropCatchModifierType type, float value, float? duration)
		{
			Dictionary<int, IDropCatchGameplayModifier> dictionary;
			if (!this.Modifiers.TryGetValue(attr, out dictionary))
			{
				dictionary = new Dictionary<int, IDropCatchGameplayModifier>();
				this.Modifiers.Add(attr, dictionary);
			}
			float? duration2 = duration;
			if (duration2 != null)
			{
				duration2 = new float?(duration2.Value * (float)Singleton<TimeUtil>.Instance.InverseMillisecond);
			}
			int num = this.ModifierIdCounter + 1;
			this.ModifierIdCounter = num;
			int num2 = num;
			dictionary.Add(num2, new IDropCatchGameplayModifier
			{
				Type = type,
				Value = value,
				Duration = duration2
			});
			this.RefreshValueByAttr(attr);
			return num2;
		}

		// Token: 0x06042DCC RID: 273868 RVA: 0x01129B3C File Offset: 0x01127D3C
		public void RemoveModifierFromAttr(IDropCatchGameplayAttribute attr, int modifierId)
		{
			Dictionary<int, IDropCatchGameplayModifier> dictionary;
			if (!this.Modifiers.TryGetValue(attr, out dictionary))
			{
				return;
			}
			dictionary.Remove(modifierId);
			if (dictionary.Count == 0)
			{
				this.Modifiers.Remove(attr);
			}
			this.RefreshValueByAttr(attr);
		}

		// Token: 0x06042DCD RID: 273869 RVA: 0x01129B80 File Offset: 0x01127D80
		private void RefreshValueByAttr(IDropCatchGameplayAttribute attr)
		{
			float baseValue = attr.GetBaseValue();
			Dictionary<int, IDropCatchGameplayModifier> dictionary;
			this.Modifiers.TryGetValue(attr, out dictionary);
			float num = baseValue;
			if (dictionary != null && dictionary.Count > 0)
			{
				float? num2 = null;
				float num3 = 1f;
				float num4 = 0f;
				foreach (IDropCatchGameplayModifier dropCatchGameplayModifier in dictionary.Values)
				{
					switch (dropCatchGameplayModifier.Type)
					{
					case EDropCatchModifierType.Override:
						num2 = new float?(dropCatchGameplayModifier.Value);
						break;
					case EDropCatchModifierType.Rate:
						num3 *= dropCatchGameplayModifier.Value;
						break;
					case EDropCatchModifierType.Offset:
						num4 += dropCatchGameplayModifier.Value;
						break;
					}
				}
				if (num2 != null)
				{
					num = num2.Value;
				}
				else
				{
					num = (num + num4) * num3;
				}
			}
			attr.SetFinalValue(num);
		}

		// Token: 0x06042DCE RID: 273870 RVA: 0x01129C74 File Offset: 0x01127E74
		public void AddSkillModifier(IDropCatchGameplayAttribute attr, int modifierId)
		{
			if (this.SkillModifiers.ContainsKey(attr))
			{
				this.SkillModifiers[attr] = modifierId;
				return;
			}
			this.SkillModifiers.Add(attr, modifierId);
		}

		// Token: 0x06042DCF RID: 273871 RVA: 0x01129CA0 File Offset: 0x01127EA0
		public void ClearAllSkillModifiers()
		{
			foreach (KeyValuePair<IDropCatchGameplayAttribute, int> keyValuePair in this.SkillModifiers)
			{
				this.RemoveModifierFromAttr(keyValuePair.Key, keyValuePair.Value);
			}
			this.SkillModifiers.Clear();
		}

		// Token: 0x06042DD0 RID: 273872 RVA: 0x01129D0C File Offset: 0x01127F0C
		public override void Destroy()
		{
			this.Modifiers.Clear();
			this.AttrToRefresh.Clear();
			this.ModifiersToDelete.Clear();
		}

		// Token: 0x0402541A RID: 152602
		private readonly Dictionary<IDropCatchGameplayAttribute, Dictionary<int, IDropCatchGameplayModifier>> Modifiers = new Dictionary<IDropCatchGameplayAttribute, Dictionary<int, IDropCatchGameplayModifier>>();

		// Token: 0x0402541B RID: 152603
		private int ModifierIdCounter;

		// Token: 0x0402541C RID: 152604
		private readonly HashSet<IDropCatchGameplayAttribute> AttrToRefresh = new HashSet<IDropCatchGameplayAttribute>();

		// Token: 0x0402541D RID: 152605
		private readonly HashSet<int> ModifiersToDelete = new HashSet<int>();

		// Token: 0x0402541E RID: 152606
		private readonly Dictionary<IDropCatchGameplayAttribute, int> SkillModifiers = new Dictionary<IDropCatchGameplayAttribute, int>();
	}
}
