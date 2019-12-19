﻿using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ParallelHelper.Extensions {
  /// <summary>
  /// Extension methods to work with method symbols.
  /// </summary>
  public static class MethodSymbolExtensions {
    /// <summary>
    /// Returns all overloads, including the method itself, of the specified method.
    /// </summary>
    /// <param name="method">The method to reslove the overloads of.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation early.</param>
    /// <returns>All identified method overloads.</returns>
    public static IEnumerable<IMethodSymbol> GetAllOverloads(this IMethodSymbol method, CancellationToken cancellationToken) {
      return method.ContainingType.GetMembers()
        .WithCancellation(cancellationToken)
        .OfType<IMethodSymbol>()
        .Where(member => member.IsStatic == method.IsStatic)
        .Where(member => member.Name.Equals(method.Name));
    }
  }
}
