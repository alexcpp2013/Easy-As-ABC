:- include(transpose) .

third_end_view_puzzle :-

    length(Rows, 8),
    maplist(gen_row(8), Rows),
    transpose(Rows, Cols),

    maplist(fd_all_different, Rows),
    maplist(fd_all_different, Cols),

    Rows = [R1,R2,R3,R4,R5,R6,R7,R8],
    Cols = [C1,C2,C3,C4,C5,C6,C7,C8],

    start(R1, 4),
    start(R2, 2),
    start(R3, 3),
    start(R4, 5),
    start(R5, 3),
    finish(R1, 6),
    finish(R2, 4),
    finish(R3, 2),
    finish(R5, 1),
    finish(R7, 2),


    start(C2, 3),
    start(C3, 4),
    start(C4, 3),
    start(C5, 5),
%   start(C6, 4),
    start(C7, 1),
%   finish(C1, 3),
%   finish(C2, 2),
    finish(C3, 5),
    finish(C4, 5),
    finish(C5, 6),
    finish(C6, 1),
    finish(C7, 4),

    maplist(fd_labeling, Rows),
    nl,
    maplist(out_row, Rows).

gen_row(N, Ls) :-
    length(Ls, N),
    fd_domain(Ls, 1, N).

out_row([]) :- nl.
out_row([H|T]) :-
    (H >= 7 -> write('-') ; write(H)),
    write(' '),
    out_row(T).

% constraint: Num is max third in that direction
start(Vars, Num) :-
    Vars = [A,B,C|_],
    A #= Num #\/ (A #>= 7 #/\ B #= Num) #\/ (A #>= 7 #/\ B #>= 7 #/\ C #= Num).

finish(Var, Num) :-
    reverse(Var, Rev), start(Rev, Num).