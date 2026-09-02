using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using UnrealEngine;
using UnrealEngine.Utils;

namespace CSharpScript.JitProfile
{
	// Token: 0x02004697 RID: 18071
	public class JitProfile
	{
		// Token: 0x0602F0A2 RID: 192674 RVA: 0x00B25774 File Offset: 0x00B23974
		[NullableContext(1)]
		private static TArray<byte> LoadFile()
		{
			TArray<byte> result = new TArray<byte>();
			if (!UKuroStaticLibrary.LoadFileToArray(UBlueprintPathsLibrary.ProjectSavedDir() + "jit_profile.txt", ref result))
			{
				UKuroStaticLibrary.LoadFileToArray(UBlueprintPathsLibrary.ProjectContentDir() + "Aki/Config/Json/jit_profile.txt", ref result);
			}
			return result;
		}

		// Token: 0x0602F0A3 RID: 192675 RVA: 0x00B257B8 File Offset: 0x00B239B8
		public static void LoadProfile()
		{
			if (JitProfile._hasInvoke)
			{
				return;
			}
			JitProfile._hasInvoke = true;
			TArray<byte> tarray = JitProfile.LoadFile();
			if (tarray.Num() == 0)
			{
				return;
			}
			try
			{
				ReadOnlySpan<byte> bytes = tarray.AsSpan<byte>();
				string[] array = Encoding.UTF8.GetString(bytes).Split('\n', StringSplitOptions.RemoveEmptyEntries);
				int num = 0;
				int num2 = 0;
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					string text = array2[i].Trim();
					if (text.Length != 0)
					{
						string[] array3 = text.Split('#', StringSplitOptions.None);
						if (array3.Length >= 2)
						{
							num++;
							string typeName = array3[0];
							string text2 = array3[1];
							try
							{
								Type type = Type.GetType(typeName);
								if (type != null)
								{
									if (text2 == ".ctor")
									{
										ConstructorInfo[] constructors = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
										if (constructors.Length != 0)
										{
											ConstructorInfo[] array4 = constructors;
											for (int j = 0; j < array4.Length; j++)
											{
												RuntimeHelpers.PrepareMethod(array4[j].MethodHandle);
											}
											num2++;
										}
									}
									else
									{
										MethodInfo method = type.GetMethod(text2, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
										if (method != null)
										{
											RuntimeHelpers.PrepareMethod(method.MethodHandle);
											num2++;
										}
									}
								}
							}
							catch (Exception)
							{
							}
						}
					}
				}
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(20, 2);
				defaultInterpolatedStringHandler.AppendLiteral("JitProfile: Finish ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(num2);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(num);
				UnrealLogger.Info(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x0401ACDB RID: 109787
		[StaticVariableRuleIgnore]
		private static bool _hasInvoke;
	}
}
